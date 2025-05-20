namespace DesignPatterns.Structural.Decorator;

public class SmsDecorator(INotifier notifier) : BaseDecorator
{
    protected override INotifier Decorated { get; } = notifier;
    public override void Send(string message)
    {
        Console.WriteLine($"SMS - {message}");
        Decorated.Send(message);
    }
}