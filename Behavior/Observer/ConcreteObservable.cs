namespace DesignPatterns.Behavior.Observer;

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