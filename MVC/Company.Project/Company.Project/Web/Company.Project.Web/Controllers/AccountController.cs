using AutoMapper;
using Company.Project.Core.WebMVC;
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

namespace Company.Project.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        private IEventFacade _eventFacade;

        public AccountController(ILogger<AccountController> logger, IMapper mapper, IEventFacadeFactory facadeFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _eventFacade = facadeFactory.Create();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(PersonViewModel personViewModel)
        {
            if (string.IsNullOrEmpty(personViewModel.FullName))
            {
                ModelState.AddModelError("", "Name field is required");
                return View(personViewModel);
            }
            var personDTO = _mapper.Map<PersonViewModel, PersonDTO>(personViewModel);
            var result = _eventFacade.CreateUser(personDTO);
            if (ModelState.IsValid)
            {
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        _logger.LogError(errorMessage.Description);
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(personViewModel);
                }
                ModelState.Clear();
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                var personDTO = _mapper.Map<PersonViewModel, PersonDTO>(personViewModel);
                var result = _eventFacade.PasswordSignIn(personDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                _logger.LogWarning("Invalid Credentials added inside login input");
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(personViewModel);
        }

        public IActionResult Logout()
        {
            _eventFacade.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
