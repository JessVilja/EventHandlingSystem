namespace EventiaWebapp.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public IList<Event> Events { get; set; }

    }
}
