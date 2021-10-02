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

namespace Company.Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventAppService _eventAppService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IEventAppService eventAppService, IMapper mapper)
        {
            _logger = logger;
            _eventAppService = eventAppService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var id = _eventAppService.GetUserId();
            dynamic operationResult;
            if (string.IsNullOrEmpty(id))
            {
                operationResult = _eventAppService.GetOnlyPublicEvents();
            }
            else
            {
                operationResult = _eventAppService.GetAllEvents();
            }

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
