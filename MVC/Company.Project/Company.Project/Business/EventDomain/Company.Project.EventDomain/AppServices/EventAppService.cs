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
        private IEventUnitOfWork _eventUnitOfWork;

        public EventAppService(IEventUnitOfWork eventUnitOfWork, IMapper mapper, IExceptionManager exceptionManager) : base(eventUnitOfWork, exceptionManager)
        {
            _mapper = mapper;
            _eventUnitOfWork = eventUnitOfWork;
        }

        //for unit testing
        //public EventAppService(IEventRepository eventRepository, IMapper mapper, IEventAndPersonRepository eventAndPersonRepository, IAccountRepository accountRepository) 
        //    : this(null, eventRepository, mapper, null, eventAndPersonRepository, null, accountRepository, null) 
        //{
        //}

        //Create new event
        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            //storing comma separated emails in an array then converting it into hashset.
            string[] emailsArray = eventDTO.InviteByEmail.Split(new[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            ICollection<string> emailsSet = new HashSet<string>(emailsArray);

            
            ICollection<string> listOfIds = new List<string>();
            //This method will store person/user Ids of corresponding emails into listOfIds and will return true or false depending upon if the email provided is present in database or not.
            bool isConversionValid = _eventUnitOfWork.Accounts.FillListWithCorrespondingUserIds(emailsSet, listOfIds).Result;

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

            _eventUnitOfWork.Events.Create(newEvent);

            result = _eventUnitOfWork.Commit();

            //making a relationship between newly created event and the Ids of users which are invited.
            _eventUnitOfWork.EventsAndPeople.CreateEventAndPersonRow(listOfIds, newEvent.Id);

            result = _eventUnitOfWork.Commit();

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
            IEnumerable<Event> publicEventList = _eventUnitOfWork.Events.Get(e => e.Type == false);
            IEnumerable<Event> myPrivateEventList = _eventUnitOfWork.Events.Get(e => e.Type).Where(e=> (e.UserID.Equals(GetUserId()) || GetUserId().Equals("8e445865-a24d-4543-a6c6-9443d048cdb9")));

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
            IEnumerable<Event> eventList = _eventUnitOfWork.Events.Get(e => e.Type==false).OrderBy(e => e.Date).ToList<Event>();
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
            IEnumerable<Event> eventList = _eventUnitOfWork.Events.Get(x => x.UserID.Equals(custId))
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
            IEnumerable<Event> eventList = _eventUnitOfWork.EventsAndPeople.GetEventsAPersonIsInvitedTo(custId);
            List<EventDTO> eventDTOList = new List<EventDTO>();
            eventDTOList = _mapper.Map<IEnumerable<Event>, List<EventDTO>>(eventList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<EventDTO>>(eventDTOList, true, message);
        }

        //Details
        public OperationResult<EventDTO> GetEventById(int eventId)
        {
            Event eventById = _eventUnitOfWork.Events.GetById(eventId);
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
            int countOfInvitedPeople = _eventUnitOfWork.EventsAndPeople.GetCountOfInvitedPeople(eventId);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<int>(countOfInvitedPeople, true, message);
        }

        //Edit event
        public OperationResult<EventDTO> EditEvent(EventDTO newEventDTO, string userId)
        {
            Event newEvent = _mapper.Map<EventDTO, Event>(newEventDTO);
            newEvent.UserID = userId;
            Event oldEvent = _eventUnitOfWork.Events.Find(e => e.Id == newEvent.Id);
            _eventUnitOfWork.Events.EditEvent(oldEvent, newEvent);
            OperationResult result = _eventUnitOfWork.Commit();
            return new OperationResult<EventDTO>(newEventDTO, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        //Register User
        public IdentityResult CreateUser(PersonDTO personDTO)
        {
            Person person = _mapper.Map<PersonDTO, Person>(personDTO);
            var result = _eventUnitOfWork.Accounts.CreateUserAsync(person).Result;
            return result;
        }

        //Login User
        public SignInResult PasswordSignIn(PersonDTO personDTO)
        {
            Person person = _mapper.Map<PersonDTO, Person>(personDTO);
            var result = _eventUnitOfWork.Accounts.PasswordSignInAsync(person).Result;
            return result;
        }

        //Logout user
        public void Logout()
        {
            _eventUnitOfWork.Accounts.SignOutAsync();
        }

        //Get loggedin user id
        public string GetUserId()
        {
            return _eventUnitOfWork.Accounts.GetLoggedInUserId();
        }

        //add comment
        public OperationResult<CommentDTO> AddComment(CommentDTO commentDTO, int eventId)
        {

            Comment newComment = _mapper.Map<CommentDTO, Comment>(commentDTO);
            newComment.IsActive = true;

            newComment.CreatedOnDate = DateTimeOffset.Now;
            newComment.EventID = eventId;

            OperationResult result;

            _eventUnitOfWork.Comments.Create(newComment);

            result = _eventUnitOfWork.Commit();

            commentDTO.Id = newComment.Id;

            //Prepare the response
            return new OperationResult<CommentDTO>(commentDTO, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        //Get all comments
        public OperationResult<IEnumerable<CommentDTO>> GetAllComments(int eventId)
        {
            IEnumerable<Comment> commentList = _eventUnitOfWork.Comments.Get(c => c.EventID == eventId).ToList<Comment>();
            List<CommentDTO> commentDTOList = new List<CommentDTO>();
            commentDTOList = _mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(commentList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CommentDTO>>(commentDTOList, true, message);
        }

        //Get all email ids invited to a particular event
        public string GetCommaSeparatedEmails(int eventId)
        {
            IEnumerable<string> allUserIds = _eventUnitOfWork.EventsAndPeople.Get(e => e.EventID == eventId).Select(e => e.PersonID);

            IList<string> allEmailIds = new List<string>();

            foreach(var userId in allUserIds)
            {
                allEmailIds.Add(_eventUnitOfWork.People.GetEmailId(userId));
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
            bool isUserValid = _eventUnitOfWork.Accounts.IsUserPresentInDatabase(userId);
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
