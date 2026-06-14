namespace choir_app.Models
{
    public class UserEventSubscription
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public int EventId { get; set; }
        public Events Event { get; set; }
    }
}