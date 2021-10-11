using Company.Project.Core.ValueObjects;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventFacade.FacadeLayer;
using Company.Project.EventFacade.Subject;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Company.Project.EventFacade
{
    public class EventFacade : IEventFacade, ICommentNotificationObserver
    {
        private IEventAppService _eventAppService;

        public EventFacade(IEventAppService eventAppService, ICommentNotificationSubject commentNotification)
        {
            _eventAppService = eventAppService;
            commentNotification.AddObserver(this);
        }

        public OperationResult<IEnumerable<EventDTO>> GetAllEvents()
        {
            //Getting current logged in user id, if it comes out to be null which means no user is logged in.
            var id = _eventAppService.GetUserId();
            dynamic operationResult;
            if (string.IsNullOrEmpty(id))
            {
                //if user not logged in
                operationResult = _eventAppService.GetOnlyPublicEvents();
            }
            else
            {
                //if user logged in.
                operationResult = _eventAppService.GetAllEvents();
            }
            return operationResult;
        }

        public OperationResult<IEnumerable<EventDTO>> GetMyEvents()
        {
            return _eventAppService.GetMyEvents();
        }

        public OperationResult<IEnumerable<EventDTO>> GetEventsImInvitedTo()
        {
            return _eventAppService.GetEventsImInvitedTo();
        }

        public OperationResult<EventDTO> GetEventById(int eventId)
        {
            return _eventAppService.GetEventById(eventId);
        }

        public OperationResult<int> GetTotalPeopleInvited(int eventId)
        {
            return _eventAppService.GetTotalPeopleInvited(eventId);
        }

        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            return _eventAppService.CreateEvent(eventDTO);
        }

        public string GetCommaSeparatedEmails(int eventId)
        {
            return _eventAppService.GetCommaSeparatedEmails(eventId);
        }

        public OperationResult<EventDTO> EditEvent(EventDTO newEventDTO, string userId)
        {
            return _eventAppService.EditEvent(newEventDTO, userId);
        }

        public OperationResult<CommentDTO> AddComment(CommentDTO commentDTO, int eventId)
        {
            return _eventAppService.AddComment(commentDTO, eventId);
        }

        public IdentityResult CreateUser(PersonDTO personDTO)
        {
            return _eventAppService.CreateUser(personDTO);
        }

        public SignInResult PasswordSignIn(PersonDTO personDTO)
        {
            return _eventAppService.PasswordSignIn(personDTO);
        }

        public void Logout()
        {
            _eventAppService.Logout();
        }

        public OperationResult<IEnumerable<CommentDTO>> GetAllComments(int eventId)
        {
            return _eventAppService.GetAllComments(eventId);
        }

        public void Notify(CommentNotificationDTO commentNotificationDTO)
        {
            var eventDTO = _eventAppService.GetEventById(commentNotificationDTO.EventId).Data;
            var eventOwnerId = eventDTO.UserID;
            var currentUserLoggedInId = _eventAppService.GetUserId();
            var currentLoggedInUserFullName = _eventAppService.GetUserFullName(currentUserLoggedInId);
            commentNotificationDTO.EventOwnerId = eventOwnerId;
            commentNotificationDTO.NameOfPersonWhoCommented = currentLoggedInUserFullName;
            var result = _eventAppService.AddCommentNotification(commentNotificationDTO);
        }

        public OperationResult<IEnumerable<CommentNotificationDTO>> GetNotificationsOfCurrentLoggedInUser()
        {
            return _eventAppService.GetNotificationsOfCurrentLoggedInUser();
        }

        public string GetEventName(int eventId)
        {
            var eventDTO = _eventAppService.GetEventById(eventId).Data;
            return eventDTO.TitleOfBook;
        }
    }
}
