namespace Server.Models.Logs;

public class LogRecord
{
    //  ServerName is usually a Server, but can also be "Browser"

    public int      Id              { get; set; } = 0;  // unique Id for records in a specific stream
    public int      StreamId        { get; set; } = 0;  // stream (problem) this record belongs to
    public int      Mask            { get; set; } = 0;  // can't be 0; type of message
    public string   ServerName      { get; set; } = ""; // can be from multiple Hunters or other servers
    public string   ServerProject   { get; set; } = ""; // Solution Server Project Name (or Web Page) 
    public string   ProjectFunction { get; set; } = ""; // Function the LogMessage came from
    public string   Message         { get; set; } = ""; // Msg text including date/time and optional values
}