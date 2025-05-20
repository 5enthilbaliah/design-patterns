namespace DesignPatterns.Structural.Decorator;

public interface INotifier
{
    void Send(string message);
}

public class DefaultNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"DEFAULT - {message}");
    }
}

public abstract class BaseDecorator : INotifier
{
    protected abstract INotifier Decorated { get; }
    public abstract void Send(string message);
}

public class FacebookDecorator(INotifier notifier) : BaseDecorator
{
    protected override INotifier Decorated { get; } = notifier;
    public override void Send(string message)
    {
        Console.WriteLine($"FACEBOOK - {message}");
        Decorated.Send(message);
    }
}

public class SmsDecorator(INotifier notifier) : BaseDecorator
{
    protected override INotifier Decorated { get; } = notifier;
    public override void Send(string message)
    {
        Console.WriteLine($"SMS - {message}");
        Decorated.Send(message);
    }
}