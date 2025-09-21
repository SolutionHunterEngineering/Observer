namespace ObserverApp.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string? RequestText { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}