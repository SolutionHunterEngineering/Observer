namespace Shared.Abstractions
{
    public class ServerDto
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public bool IsConnected { get; set; }
    }
}