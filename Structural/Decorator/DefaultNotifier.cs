namespace DesignPatterns.Structural.Decorator;

public class DefaultNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"DEFAULT - {message}");
    }
}