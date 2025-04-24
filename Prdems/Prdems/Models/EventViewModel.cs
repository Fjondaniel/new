namespace Prdems.Models
{
    public class EventViewModel
    {
        public required string EventName { get; set; }
        public required string EventDescription { get; set; }
        public required string Location { get; set; }
        public required DateTimeOffset CreatedDate { get; set; }
        public required string Category { get; set; }
        public required int Attendee { get; set; }
    }
}
