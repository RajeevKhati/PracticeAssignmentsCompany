using AutoMapper;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class EventController : Controller
    {

        private readonly ILogger<EventController> _logger;
        private readonly IEventAppService _eventAppService;
        private readonly IMapper _mapper;

        public EventController(ILogger<EventController> logger, IEventAppService eventAppService, IMapper mapper)
        {
            _logger = logger;
            _eventAppService = eventAppService;
            _mapper = mapper;
        }

        [Authorize]
        // My events
        public ActionResult MyEvents()
        {
            var operationResult = _eventAppService.GetMyEvents();
            IEnumerable<EventDTO> myEventsDTO = operationResult.Data;
            IEnumerable<EventViewModel> myEventsViewModel = _mapper.Map<IEnumerable<EventDTO>, IEnumerable<EventViewModel>>(myEventsDTO);
            return View(myEventsViewModel);
        }

        [Authorize]
        //events invited to
        public ActionResult EventsInvitedTo()
        {
            var operationResult = _eventAppService.GetEventsImInvitedTo();
            IEnumerable<EventDTO> eventsInvitedToDTO = operationResult.Data;
            IEnumerable<EventViewModel> eventsInvitedToViewModel = _mapper.Map<IEnumerable<EventDTO>, IEnumerable<EventViewModel>>(eventsInvitedToDTO);
            return View(eventsInvitedToViewModel);
        }


        // GET: EventController/Details/5 done
        [Route("Event/Details/{eventId:int}")]
        public ActionResult Details(int eventId)
        {
            var operationResult = _eventAppService.GetEventById(eventId);
            if (!operationResult.IsSuccess)
            {
                ErrorViewModel errorView = new ErrorViewModel();
                if (operationResult.MainMessage.Code.Equals("104"))
                {
                    _logger.LogError(operationResult.MainMessage.Text);
                    errorView = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                }
                else
                {
                    _logger.LogError(operationResult.MainMessage.Text);
                    errorView = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                }
                return View("Error", errorView);
            }
            EventDTO eventDTO = operationResult.Data;
            EventViewModel eventViewModel = _mapper.Map<EventDTO, EventViewModel>(eventDTO);
            ViewBag.count = _eventAppService.GetTotalPeopleInvited(eventId).Data;
            return View(eventViewModel);
        }

        [Authorize]
        // GET: EventController/Create done
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: EventController/Create done
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var eventDTO = _mapper.Map<EventViewModel, EventDTO>(eventViewModel);
                var operationResult = _eventAppService.CreateEvent(eventDTO);
                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation($"A new event is created by user with Id {eventDTO.Id}");
                    return this.RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", operationResult.MainMessage.Text);
                _logger.LogError(operationResult.MainMessage.Text);
                foreach (var error in operationResult.AssociatedMessages)
                {
                    ModelState.AddModelError("", error.Text);
                    _logger.LogError(error.Text);
                }
            }
            return View();
            
        }


        // GET: EventController/Edit/5
        [Authorize]
        [Route("Event/Edit/{id:int}/{userId}")]
        public ActionResult Edit(int id, string userId)
        {
            //Handle if user tries to manipulate eventid inside url

            var operationResult = _eventAppService.GetEventById(id);
            if (!operationResult.IsSuccess)
            {
                ErrorViewModel errorView = new ErrorViewModel();
                _logger.LogError(operationResult.MainMessage.Text);
                errorView = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", errorView);
            }

            EventDTO eventDTO = operationResult.Data;
            EventViewModel eventViewModel = _mapper.Map<EventDTO, EventViewModel>(eventDTO);
            string commaSeparatedEmails = _eventAppService.GetCommaSeparatedEmails(id);
            eventViewModel.InviteByEmail = commaSeparatedEmails;
            ViewBag.userId = userId;
            ViewBag.disabled = false;
            return View(eventViewModel);
        }


        // POST: EventController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Event/Edit/{id:int}/{userId}")]
        public ActionResult Edit(EventViewModel eventViewModel, string userId)
        {
            if (ModelState.IsValid)
            {
                EventDTO eventDTO = _mapper.Map<EventViewModel, EventDTO>(eventViewModel);
                var operationResult = _eventAppService.EditEvent(eventDTO, userId);
                int id = operationResult.Data.Id;
                return this.RedirectToAction("Details", new { eventId = id });
            }
            string commaSeparatedEmails = _eventAppService.GetCommaSeparatedEmails(eventViewModel.Id);
            eventViewModel.InviteByEmail = commaSeparatedEmails;
            ViewBag.userId = userId;
            ViewBag.disabled = true;
            return View(eventViewModel);
            
        }

        [Authorize]
        public ActionResult AddComment(int eventId)
        {
            ViewBag.eventId = eventId;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddComment(CommentViewModel commentViewModel, int eventId)
        {
            CommentDTO commentDTO = _mapper.Map<CommentViewModel, CommentDTO>(commentViewModel);
            var commentResult = _eventAppService.AddComment(commentDTO, eventId);
            if (!commentResult.IsSuccess)
            {
                ModelState.AddModelError("", commentResult.MainMessage.Text);
                _logger.LogError(commentResult.MainMessage.Text);
                foreach (var error in commentResult.AssociatedMessages)
                {
                    ModelState.AddModelError("", error.Text);
                    _logger.LogError(error.Text);
                }
                return View(commentViewModel);
            }

            _logger.LogInformation($"A new comment added inside event where event's Id is {eventId}");
            return this.RedirectToAction("Details", new { eventId = eventId });
        }
    }
}
