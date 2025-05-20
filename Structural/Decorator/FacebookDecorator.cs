namespace DesignPatterns.Structural.Decorator;

public class FacebookDecorator(INotifier notifier) : BaseDecorator
{
    protected override INotifier Decorated { get; } = notifier;
    public override void Send(string message)
    {
        Console.WriteLine($"FACEBOOK - {message}");
        Decorated.Send(message);
    }
}