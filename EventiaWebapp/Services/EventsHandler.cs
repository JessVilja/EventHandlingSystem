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
    }
}
