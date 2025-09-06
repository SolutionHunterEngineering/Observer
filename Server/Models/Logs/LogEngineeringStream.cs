using Microsoft.VisualBasic;

namespace Server.Models.Logs;

public class LogEngineerStream
{
    public int      Id          { get; set; } = 0;  // unique ID for the type of problem to be solved
    public int      EngineerId  { get; set; } = 0;  // Id of the Engineer doing the research
    public string   ProblemType { get; set; } = ""; // (short) uniquely defines what the research is about
}