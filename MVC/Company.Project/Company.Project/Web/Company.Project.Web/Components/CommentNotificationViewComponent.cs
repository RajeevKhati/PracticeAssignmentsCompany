using AutoMapper;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventFacade.FacadeFactory;
using Company.Project.EventFacade.FacadeLayer;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Components
{
    public class CommentNotificationViewComponent : ViewComponent
    {
        private readonly ILogger<CommentNotificationViewComponent> _logger;
        private readonly IMapper _mapper;
        private IEventFacade _eventFacade;

        public CommentNotificationViewComponent(ILogger<CommentNotificationViewComponent> logger, IMapper mapper, IEventFacadeFactory facadeFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _eventFacade = facadeFactory.Create();
        }

        [Authorize]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _eventFacade.GetNotificationsOfCurrentLoggedInUser();
            var commentNotificationsDTO = result.Data;
            var commentNotifications = _mapper.Map<IEnumerable<CommentNotificationDTO>, IEnumerable<CommentNotificationViewModel>>(commentNotificationsDTO);

            foreach(var commentNotificationViewModel in commentNotifications)
            {
                commentNotificationViewModel.EventName = _eventFacade.GetEventName(commentNotificationViewModel.EventId);
            }

            return View(commentNotifications);
        }
    }
}
