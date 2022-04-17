using System.Linq;
using EventiaWebapp.Data;
using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class OrganizerHandler
    {
        private readonly EventiaDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrganizerHandler(EventiaDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddNewEvent(Event events, User organizer)
        {

            var organizerQuery = await _context.Users.Where(a => a.Id == organizer.Id).FirstOrDefaultAsync();
            var newEvent = new Event
            {
                Title = events.Title,
                Description = events.Description,
                Date = events.Date,
                Organizer = organizerQuery,
                Place = events.Place,
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Event>> SingleOrganizerEventList(User organizer)
        {
            var singleOrganizer = await _context.Users.Where(a => a.Id == organizer.Id).FirstOrDefaultAsync();
            var events = _context.Events.Where(e => e.Organizer == singleOrganizer);
            var eventList = await events.ToListAsync();

            return eventList;
        }


    }
}
