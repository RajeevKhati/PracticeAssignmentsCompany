using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.EventDomain.AppServices.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.AppServices
{
    public interface IEventAppService : IAppService
    {
        OperationResult<EventDTO> CreateEvent(EventDTO item);
        OperationResult<IEnumerable<EventDTO>> GetAllEvents();//
        OperationResult<IEnumerable<EventDTO>> GetMyEvents();
        OperationResult<IEnumerable<EventDTO>> GetEventsImInvitedTo();
        OperationResult<EventDTO> GetEventById(int eventId);//
        OperationResult<int> GetTotalPeopleInvited(int eventId);//
        OperationResult<EventDTO> EditEvent(EventDTO eventDTO, string userId);
        IdentityResult CreateUser(PersonDTO personDTO);
        SignInResult PasswordSignIn(PersonDTO personDTO);
        void Logout();
        string GetUserId();
        OperationResult<CommentDTO> AddComment(CommentDTO commentDTO, int eventId);
        OperationResult<IEnumerable<CommentDTO>> GetAllComments(int eventId);//
        OperationResult<IEnumerable<EventDTO>> GetOnlyPublicEvents();//
        string GetCommaSeparatedEmails(int eventId);
        OperationResult<bool> IsUserValid(string userId);
        string GetUserFullName(string userId);
        OperationResult<CommentNotificationDTO> AddCommentNotification(CommentNotificationDTO commentNotificationDTO);
        OperationResult<IEnumerable<CommentNotificationDTO>> GetNotificationsOfCurrentLoggedInUser();
    }
}
