using AutoMapper;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventFacade.FacadeFactory;
using Company.Project.EventFacade.FacadeLayer;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Components
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ILogger<CommentViewComponent> _logger;
        private readonly IMapper _mapper;
        private IEventFacade _eventFacade;

        public CommentViewComponent(ILogger<CommentViewComponent> logger, IMapper mapper, IEventFacadeFactory facadeFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _eventFacade = facadeFactory.Create();
        }
        public async Task<IViewComponentResult> InvokeAsync(int eventId)
        {
            var commentResult = _eventFacade.GetAllComments(eventId).Data;
            IEnumerable<CommentViewModel> commentList = _mapper.Map<IEnumerable<CommentDTO>, IEnumerable<CommentViewModel>>(commentResult);
            return View(commentList);
        }
    }
}
