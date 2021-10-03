using AutoMapper;
using Company.Project.Core.AppServices;
using Company.Project.Core.ExceptionManagement;
using Company.Project.Core.ValueObjects;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.AppServices
{
    /// <summary>
    /// In this class Object comes and returns in Dto form.
    /// It handles all the operation for modifying/getting from database.
    /// </summary>
    public class EventAppService : AppService, IEventAppService
    {

        private IMapper _mapper;
        private readonly IEventAndPersonRepository _eventAndPersonRepository;
        private readonly IPersonRepository _personRepository;

        private IEventRepository _eventRepository;
        private IAccountRepository _accountRepository;
        private readonly ICommentRepository _commentRepository;

        public EventAppService(IEventUnitOfWork unitOfWork, IEventRepository eventRepository, IMapper mapper, IExceptionManager exceptionManager, IEventAndPersonRepository eventAndPersonRepository, IPersonRepository personRepository, IAccountRepository accountRepository, ICommentRepository commentRepository) : base(unitOfWork, exceptionManager)
        {
            _mapper = mapper;
            _eventAndPersonRepository = eventAndPersonRepository;
            _personRepository = personRepository;
            _eventRepository = eventRepository;
            _accountRepository = accountRepository;
            _commentRepository = commentRepository;
        }

        //for unit testing
        public EventAppService(IEventRepository eventRepository, IMapper mapper, IEventAndPersonRepository eventAndPersonRepository, IAccountRepository accountRepository) 
            : this(null, eventRepository, mapper, null, eventAndPersonRepository, null, accountRepository, null) 
        {
        }

        //Create new event
        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            //storing comma separated emails in an array then converting it into hashset.
            string[] emailsArray = eventDTO.InviteByEmail.Split(new[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            ICollection<string> emailsSet = new HashSet<string>(emailsArray);

            
            ICollection<string> listOfIds = new List<string>();
            //This method will store person/user Ids of corresponding emails into listOfIds and will return true or false depending upon if the email provided is present in database or not.
            bool isConversionValid = _accountRepository.FillListWithCorrespondingUserIds(emailsSet, listOfIds).Result;

            if (!isConversionValid)
            {
                Message message = new Message(string.Empty, "User from specified emails in \"Invite By Email Field\" is not valid");
                return new OperationResult<EventDTO>(eventDTO, false, message);
            }

            //Creating new event
            Event newEvent = _mapper.Map<EventDTO, Event>(eventDTO);
            newEvent.IsActive = true;

            newEvent.CreatedOnDate = DateTimeOffset.Now;
            newEvent.UserID = GetUserId();

            OperationResult result;

            _eventRepository.Create(newEvent);

            result = UnitOfWork.Commit();

            //making a relationship between newly created event and the Ids of users which are invited.
            _eventAndPersonRepository.CreateEventAndPersonRow(listOfIds, newEvent.Id);

            eventDTO.Id = newEvent.Id;

            //Prepare the response
            return new OperationResult<EventDTO>(eventDTO, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        //Get all events
        /// <summary>
        /// Returns all events sorted by date.
        /// It also ensures only private events associated with the current user is returned.
        /// </summary>
        public OperationResult<IEnumerable<EventDTO>> GetAllEvents()
        {
            IEnumerable<Event> publicEventList = _eventRepository.Get(e => e.Type == false);
            IEnumerable<Event> myPrivateEventList = _eventRepository.Get(e => e.Type).Where(e=> (e.UserID.Equals(GetUserId()) || GetUserId().Equals("8e445865-a24d-4543-a6c6-9443d048cdb9")));

            var myListOfEvents = publicEventList.Concat(myPrivateEventList);
            IEnumerable<Event> eventList = myListOfEvents.OrderBy(e => e.Date).ToList<Event>();

            List<EventDTO> eventDTOList = new List<EventDTO>();
            eventDTOList = _mapper.Map<IEnumerable<Event>, List<EventDTO>>(eventList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<EventDTO>>(eventDTOList, true, message);
        }

        //Get only public events
        public OperationResult<IEnumerable<EventDTO>> GetOnlyPublicEvents()
        {
            IEnumerable<Event> eventList = _eventRepository.Get(e => e.Type==false).OrderBy(e => e.Date).ToList<Event>();
            List<EventDTO> eventDTOList = new List<EventDTO>();
            eventDTOList = _mapper.Map<IEnumerable<Event>, List<EventDTO>>(eventList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<EventDTO>>(eventDTOList, true, message);
        }

        //MyEvents
        /// <summary>
        /// Return events created by current logged in user in ascending order of Date.
        /// </summary>
        public OperationResult<IEnumerable<EventDTO>> GetMyEvents()
        {
            string custId = GetUserId();
            IEnumerable<Event> eventList = _eventRepository.Get(x => x.UserID.Equals(custId))
                                                               .OrderBy(e => e.Date).ToList<Event>();
            List<EventDTO> eventDTOList = new List<EventDTO>();
            eventDTOList = _mapper.Map<IEnumerable<Event>, List<EventDTO>>(eventList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<EventDTO>>(eventDTOList, true, message);
        }

        //EventsInvitedTo
        public OperationResult<IEnumerable<EventDTO>> GetEventsImInvitedTo()
        {
            string custId = GetUserId();
            IEnumerable<Event> eventList = _eventAndPersonRepository.GetEventsAPersonIsInvitedTo(custId);
            List<EventDTO> eventDTOList = new List<EventDTO>();
            eventDTOList = _mapper.Map<IEnumerable<Event>, List<EventDTO>>(eventList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<EventDTO>>(eventDTOList, true, message);
        }

        //Details
        public OperationResult<EventDTO> GetEventById(int eventId)
        {
            Event eventById = _eventRepository.GetById(eventId);
            if (eventById == null)
            {
                Message message = new Message("104", $"No event found with given Id {eventId}");
                return new OperationResult<EventDTO>(null, false, message);
            }
            else
            {
                EventDTO eventDTO = new EventDTO();
                eventDTO = _mapper.Map<Event, EventDTO>(eventById);
                Message message = new Message(string.Empty, "Return Successfully");
                return new OperationResult<EventDTO>(eventDTO, true, message);
            }
            
        }

        //count of people in a particular event
        public OperationResult<int> GetTotalPeopleInvited(int eventId)
        {
            int countOfInvitedPeople = _eventAndPersonRepository.GetCountOfInvitedPeople(eventId);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<int>(countOfInvitedPeople, true, message);
        }

        //Edit event
        public OperationResult<EventDTO> EditEvent(EventDTO newEventDTO, string userId)
        {
            Event newEvent = _mapper.Map<EventDTO, Event>(newEventDTO);
            newEvent.UserID = userId;
            Event oldEvent = _eventRepository.Find(e => e.Id == newEvent.Id);
            _eventRepository.EditEvent(oldEvent, newEvent);
            OperationResult result = UnitOfWork.Commit();
            return new OperationResult<EventDTO>(newEventDTO, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        //Register User
        public IdentityResult CreateUser(PersonDTO personDTO)
        {
            Person person = _mapper.Map<PersonDTO, Person>(personDTO);
            var result = _accountRepository.CreateUserAsync(person).Result;
            return result;
        }

        //Login User
        public SignInResult PasswordSignIn(PersonDTO personDTO)
        {
            Person person = _mapper.Map<PersonDTO, Person>(personDTO);
            var result = _accountRepository.PasswordSignInAsync(person).Result;
            return result;
        }

        //Logout user
        public void Logout()
        {
            _accountRepository.SignOutAsync();
        }

        //Get loggedin user id
        public string GetUserId()
        {
            return _accountRepository.GetLoggedInUserId();
        }

        //add comment
        public OperationResult<CommentDTO> AddComment(CommentDTO commentDTO, int eventId)
        {

            Comment newComment = _mapper.Map<CommentDTO, Comment>(commentDTO);
            newComment.IsActive = true;

            newComment.CreatedOnDate = DateTimeOffset.Now;
            newComment.EventID = eventId;

            OperationResult result;

            _commentRepository.Create(newComment);

            result = UnitOfWork.Commit();

            commentDTO.Id = newComment.Id;

            //Prepare the response
            return new OperationResult<CommentDTO>(commentDTO, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        //Get all comments
        public OperationResult<IEnumerable<CommentDTO>> GetAllComments(int eventId)
        {
            IEnumerable<Comment> commentList = _commentRepository.Get(c => c.EventID == eventId).ToList<Comment>();
            List<CommentDTO> commentDTOList = new List<CommentDTO>();
            commentDTOList = _mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(commentList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CommentDTO>>(commentDTOList, true, message);
        }

        //Get all email ids invited to a particular event
        public string GetCommaSeparatedEmails(int eventId)
        {
            IEnumerable<string> allUserIds = _eventAndPersonRepository.Get(e => e.EventID == eventId).Select(e => e.PersonID);

            IList<string> allEmailIds = new List<string>();

            foreach(var userId in allUserIds)
            {
                allEmailIds.Add(_personRepository.GetEmailId(userId));
            }

            StringBuilder commaSeparatedEmails = new StringBuilder();

            for(int i=0; i<allEmailIds.Count; i++)
            {
                commaSeparatedEmails.Append(allEmailIds[i]);
                if(i!=allEmailIds.Count-1)
                    commaSeparatedEmails.Append(",");
            }

            return commaSeparatedEmails.ToString();
        }

        //checking if given user id is valid
        public OperationResult<bool> IsUserValid(string userId)
        {
            bool isUserValid = _accountRepository.IsUserPresentInDatabase(userId);
            if (isUserValid)
            {
                return new OperationResult<bool>(true, true, new Message("", "success"));
            }
            else
            {
                Message message = new Message("", "User Not Found");
                return new OperationResult<bool>(false, false, message);
            }
        }

    }
}
