using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Company.Project.Web.Models;
using Company.Project.EventDomain.AppServices;
using AutoMapper;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.Core.WebMVC;
using Company.Project.EventFacade.FacadeFactory;
using Company.Project.EventFacade.FacadeLayer;

namespace Company.Project.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        private IEventFacade _eventFacade;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IEventFacadeFactory facadeFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _eventFacade = facadeFactory.Create();
        }

        public IActionResult Index()
        {
            var operationResult = _eventFacade.GetAllEvents();

            var events = operationResult.Data;
            var eventViewModel = _mapper.Map<IEnumerable<EventDTO>,IEnumerable<EventViewModel>>(events);
            return View(eventViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/customer-support")]
        public IActionResult CustomerSupport()
        {
            return Redirect("https://helpdesk.nagarro.com");
        }
    }
}
