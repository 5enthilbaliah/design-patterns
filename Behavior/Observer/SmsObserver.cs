namespace DesignPatterns.Behavior.Observer;

public class SmsObserver : IObserver
{
    private long Id { get; } = DateTime.UtcNow.Ticks;
    
    public void Update(string message)
    {
        Console.WriteLine($"{Id} SMS notify {message}");
    }
}