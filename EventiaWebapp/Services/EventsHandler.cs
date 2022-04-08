using EventiaWebapp.Data;
using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventsHandler
    {
        private readonly EventiaDbContext _context;

        public EventsHandler(EventiaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetEvents()
        {
            var items = await _context.Events.ToListAsync();
            return items;
        }

   /*
        public async Task<User> GetSingleAttendee(User user)
        {
            var singleAttendee = await _context.Users.Where(A => A.Id == id).FirstOrDefaultAsync();
            return singleAttendee; 
        }  */

        public async Task<Event> GetSingleEventById(int id)
        {
            var singleEvent = await _context.Events.Where(E => E.Id == id).FirstOrDefaultAsync();
            return singleEvent;
        }
        
        public async Task<Event> JoinedEvent(User user, int id)
        {
            
            var query = await _context.Users.Where(a => a.Id == user.Id).Include(e => e.JoinedEvents).FirstOrDefaultAsync();
            var query2 = await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();

            query.JoinedEvents.Add(query2);

            _context.Update(query);
            await _context.SaveChangesAsync();

            return query2;
        } 

        public async Task<List<Event>> SingleAttendeeEventList(User attendee)
        {
            var singleAttendeeQuery = await _context.Users.Where(a => a.Id == attendee.Id).FirstOrDefaultAsync();

            var events = _context.Events.Where(e => e.Attendees.Contains(singleAttendeeQuery)).Include(o => o.Organizer);
            var listOfEvents = await events.ToListAsync();
            return listOfEvents;
        }
    }
}
