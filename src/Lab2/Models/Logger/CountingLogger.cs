namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Logger;

public class CountingLogger : ILogger
{
    private readonly List<string> _messages = new();

    public IReadOnlyCollection<string> Messages => _messages.AsReadOnly();

    public void Log(string message)
    {
        _messages.Add(message);
    }
}