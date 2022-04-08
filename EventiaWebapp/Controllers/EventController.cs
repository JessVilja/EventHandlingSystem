using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventController : Controller
    {
        private readonly EventsHandler _EventsHandler;
        private readonly UserManager<User> _userManager;

        public EventController(EventsHandler eventHandler, UserManager<User> userManager)
        {
            _EventsHandler = eventHandler;
            _userManager = userManager;
        }
        public async Task <IActionResult> Index()
        {
            return View("Index");
        }

        public async Task<IActionResult> Events()
        {
            return View("Events");
        }
        /*
        public User GetCurrentUser()
        {
            var currentUser = user;
            var user = _userManager.GetUserAsync(User).Result;
            return user;
        } */
        public async Task<IActionResult> MyEvents()
        {
            var attendee = await _userManager.GetUserAsync(User);
           // var attendee = await _EventsHandler.GetSingleAttendee(1);
            return View("MyEvents", attendee); 
           //return View();
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
    }
}
