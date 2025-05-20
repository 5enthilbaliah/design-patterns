namespace DesignPatterns.Behavior.Observer;

public interface IObservable
{
    IList<IObserver> Listeners { get; }
    void Subscribe(IObserver listener);
    void Unsubscribe(IObserver listener);
    void Notify(string message);
}

public class ConcreteObservable : IObservable
{
    public IList<IObserver> Listeners { get; } = new List<IObserver>();


    public void Subscribe(IObserver listener)
    {
        Listeners.Add(listener);
    }

    public void Unsubscribe(IObserver listener)
    {
        Listeners.Remove(listener);
    }

    public void Notify(string message)
    {
        foreach (var listener in Listeners)
        {
            listener.Update(message);
        }
    }
}

public interface IObserver
{
    void Update(string message);
}

public class EmailObserver : IObserver
{
    private long Id { get; } = DateTime.UtcNow.Ticks;

    public void Update(string message)
    {
        Console.WriteLine($"{Id} Email notify {message}");
    }
}

public class SmsObserver : IObserver
{
    private long Id { get; } = DateTime.UtcNow.Ticks;
    
    public void Update(string message)
    {
        Console.WriteLine($"{Id} SMS notify {message}");
    }
}