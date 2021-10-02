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

namespace Company.Project.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IEventAppService _eventAppService;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IEventAppService eventAppService, IMapper mapper)
        {
            _logger = logger;
            _eventAppService = eventAppService;
            _mapper = mapper;
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
            var result = _eventAppService.CreateUser(personDTO);
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
                var result = _eventAppService.PasswordSignIn(personDTO);
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
            _eventAppService.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}
