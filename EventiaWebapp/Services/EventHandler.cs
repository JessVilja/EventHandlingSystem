using EventiaWebapp.Models;

namespace EventiaWebapp.Services
{
    public class EventHandler
    {
        public List<Event> Events { get; set; }

        public EventHandler()
        {
            Events = new List<Event>()
            {
                new Event
                {
                    Title = "Cabaret",
                    Description = "In a time when the world is changing forever, there is one place where everyone can be free…",
                    Place = "Kit Kat Club",
                    Address = "Northumberland Ave, London WC2N 5DE, United Kingdom",
                    Date = new DateTime(2022, 10, 22),
                    Spots_available = 22,
                },
                new Event
                {
                    Title = "Pretty Woman, The Musical",
                    Description = "The '80s romcom is now a Broadway musical that hits all the right notes",
                    Place = "Savoy Theatre",
                    Address = "Savoy Ct, Strand, London WC2R 0ET, United Kingdom",
                    Date = new DateTime(2022, 09, 10),
                    Spots_available = 165,
                },
                new Event
                {
                    Title = "The Book of Mormon",
                    Description = "The Book of Mormon musical follows the journey of two Mormon missionaries who travel to Africa to preach their religion.",
                    Place = "Prince of Wales Theatre",
                    Address = "Coventry St, London W1D 6AS, United Kingdom",
                    Date = new DateTime(2023, 1, 28),
                    Spots_available = 89,
                },
                new Event
                {
                    Title = "Disney's The Lion King",
                    Description = "Based on the hit 1994 Walt Disney animated film of the same name, The Lion King musical is set in the African Pridelands and tells the coming of age story of lion cub Simba",
                    Place = "Lyceum Theatre",
                    Address = " 21 Wellington St, London WC2E 7RQ, United Kingdom",
                    Date = new DateTime(2022, 6, 5),
                    Spots_available = 245,
                },

            };
        }

        public List<Event> GetEvents()
        {
            return Events.ToList();
        }
    }
}
