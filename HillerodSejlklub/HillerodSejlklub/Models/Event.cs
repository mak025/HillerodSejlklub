namespace HillerodSejlklub.Models
{
    public class Event
    {
        public List<Event> eventList;

        public string Name { get; set; }
        public DateTime StartDT { get; set; }
        public DateTime EndDT { get; set; }
        public string Description { get; set; }


        public Event(string name , DateTime startDT, DateTime endDT, string description)
        {
            Name = name; 
            StartDT = startDT;
            EndDT = endDT;
            Description = description;

        }
    }
}
