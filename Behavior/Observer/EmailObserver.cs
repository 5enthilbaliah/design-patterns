namespace DesignPatterns.Behavior.Observer;

public class EmailObserver : IObserver
{
    private long Id { get; } = DateTime.UtcNow.Ticks;

    public void Update(string message)
    {
        Console.WriteLine($"{Id} Email notify {message}");
    }
}