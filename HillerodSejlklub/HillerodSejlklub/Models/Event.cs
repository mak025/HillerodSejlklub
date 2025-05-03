namespace HillerodSejlklub.Models
{
    /// <summary>
    /// Represents an event with a name, start and end date, and description.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// A list of events.
        /// </summary>
        public List<Event> eventList;

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the event.
        /// </summary>
        public DateTime StartDT { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the event.
        /// </summary>
        public DateTime EndDT { get; set; }

        /// <summary>
        /// Gets or sets the description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="name">The name of the event.</param>
        /// <param name="startDT">The start date and time of the event.</param>
        /// <param name="endDT">The end date and time of the event.</param>
        /// <param name="description">The description of the event.</param>
        public Event(string name, DateTime startDT, DateTime endDT, string description)
        {
            Name = name;
            StartDT = startDT;
            EndDT = endDT;
            Description = description;
        }
    }
}
