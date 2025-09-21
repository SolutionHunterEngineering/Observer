namespace ObserverApp.Models
{
    public class Link
    {
        public int Id { get; set; }

        // Example foreign keys (can refine once you define relationships)
        public int SourceId { get; set; }
        public int TargetId { get; set; }
    }
}