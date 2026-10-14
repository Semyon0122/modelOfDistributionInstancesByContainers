namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Logger;

public class CountingLogger : ILogger
{
    public LinkedList<string> Messages { get; } = new();

    public void Log(string message)
    {
        Messages.AddLast(message);
    }
}