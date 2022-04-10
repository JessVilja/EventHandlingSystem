using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EventiaWebapp.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [InverseProperty("Organizer")]
        public IList<Event> HostedEvent { get; set; }

        [InverseProperty("Attendees")]
        public IList<Event> JoinedEvents { get; set; }
    }
}
