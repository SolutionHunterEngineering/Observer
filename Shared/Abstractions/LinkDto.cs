namespace Shared.Abstractions
{
    public class LinkDto
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        // Add navigation properties if needed
    }
}