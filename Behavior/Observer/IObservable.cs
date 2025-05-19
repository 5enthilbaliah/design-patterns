namespace DesignPatterns.Behavior.Observer;

public interface IObservable
{
    IList<IObserver> Listeners { get; }
    void Subscribe(IObserver listener);
    void Unsubscribe(IObserver listener);
    void Notify(string message);
}