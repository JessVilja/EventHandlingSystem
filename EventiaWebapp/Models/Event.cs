namespace EventiaWebapp.Models
{
    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string place { get; set; }
        public string address { get; set; }
        public DateTime date { get; set; }
        public int spots_available { get; set; }

    }
}
