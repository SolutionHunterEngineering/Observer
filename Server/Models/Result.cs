namespace ObserverApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string? Outcome { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    }
}