using Company.Project.Core.ValueObjects;
using Company.Project.EventDomain.AppServices.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventFacade.FacadeLayer
{
    public interface IEventFacade
    {
        OperationResult<IEnumerable<EventDTO>> GetAllEvents();
        OperationResult<IEnumerable<EventDTO>> GetMyEvents();
        OperationResult<IEnumerable<EventDTO>> GetEventsImInvitedTo();
        OperationResult<EventDTO> GetEventById(int eventId);
        OperationResult<int> GetTotalPeopleInvited(int eventId);
        OperationResult<EventDTO> CreateEvent(EventDTO eventDTO);
        string GetCommaSeparatedEmails(int eventId);
        OperationResult<EventDTO> EditEvent(EventDTO newEventDTO, string userId);
        OperationResult<CommentDTO> AddComment(CommentDTO commentDTO, int eventId);
        IdentityResult CreateUser(PersonDTO personDTO);
        SignInResult PasswordSignIn(PersonDTO personDTO);
        void Logout();
        OperationResult<IEnumerable<CommentDTO>> GetAllComments(int eventId);
    }
}
