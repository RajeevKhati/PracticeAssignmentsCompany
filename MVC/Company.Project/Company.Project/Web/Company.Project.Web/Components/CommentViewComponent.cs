using AutoMapper;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.DTOs;
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
        private readonly IEventAppService _eventAppService;
        private readonly IMapper _mapper;

        public CommentViewComponent(ILogger<CommentViewComponent> logger, IEventAppService eventAppService, IMapper mapper)
        {
            _logger = logger;
            _eventAppService = eventAppService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int eventId)
        {
            var commentResult = _eventAppService.GetAllComments(eventId).Data;
            IEnumerable<CommentViewModel> commentList = _mapper.Map<IEnumerable<CommentDTO>, IEnumerable<CommentViewModel>>(commentResult);
            return View(commentList);
        }
    }
}
