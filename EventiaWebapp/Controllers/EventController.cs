﻿using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventController : Controller
    {
        private readonly EventsHandler _EventsHandler;
        private readonly OrganizerHandler _organizerHandler;
        private readonly UserManager<User> _userManager;

        public EventController(EventsHandler eventHandler, OrganizerHandler organizerHandler, UserManager<User> userManager)
        {
            _EventsHandler = eventHandler;
            _organizerHandler = organizerHandler;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View("Index");
        }

        public async Task<IActionResult> Events()
        {
            return View("Events");
        }

        public async Task<IActionResult> MyEvents()
        {
            var attendee = await _userManager.GetUserAsync(User);
            return View("MyEvents", attendee);
        }

        public async Task<IActionResult> Join(int id)
        {
            var singleEvent = await _EventsHandler.GetSingleEventById(id);
            return View(singleEvent);
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var person = await _userManager.GetUserAsync(User);
            var eventJoined = await _EventsHandler.JoinedEvent(person, id);
            return View(eventJoined);

        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([Bind("Id, Title, Description, Place, Date, Spots_available")] Event events)
        {
            var person = await _userManager.GetUserAsync(User);
            await _organizerHandler.AddNewEvent(events, person);
            return View();
        }

        
        public async Task<IActionResult> AddEvent()
        {
            return View();
        }

        public async Task<IActionResult> OrganizeEvent()
        {
            return View();
        }
    }
}
