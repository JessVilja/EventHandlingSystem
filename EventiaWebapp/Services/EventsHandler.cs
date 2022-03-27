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

        public async Task<Attendee> GetSingleAttendee(int id)
        {
            var singleAttendee = await _context.Attendees.Where(A => A.Id == id).FirstOrDefaultAsync();
            return singleAttendee;
        }

        public async Task<Event> GetSingleEventById(int id)
        {
            var singleEvent = await _context.Events.Where(E => E.Id == id).FirstOrDefaultAsync();
            return singleEvent;
        }

        public async Task<Event> JoinedEvent(Attendee attendee, int Eid)
        {
            var query = await _context.Attendees.Where(a => a.Id == attendee.Id).Include(e => e.Events).FirstOrDefaultAsync();
            var query2 = await _context.Events.Where(e => e.Id == Eid).FirstOrDefaultAsync();

            query.Events.Add(query2);

            _context.Update(query);
            await _context.SaveChangesAsync();

            return query2;
        }

        public async Task<List<Event>> SingleAttendeeEventList(Attendee attendee)
        {
            var singleAttendeeQuery = await _context.Attendees.Where(a => a.Id == attendee.Id).Include(ae => ae.Events).FirstOrDefaultAsync();

            var events = _context.Events.Where(e => e.Attendees.Contains(singleAttendeeQuery)).Include(o => o.Organizer);
            var listOfEvents = await events.ToListAsync();
            return listOfEvents;
        }
    }
}
