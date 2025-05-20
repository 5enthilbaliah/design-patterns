namespace DesignPatterns.Structural.Decorator;

public abstract class BaseDecorator : INotifier
{
    protected abstract INotifier Decorated { get; }
    public abstract void Send(string message);
}