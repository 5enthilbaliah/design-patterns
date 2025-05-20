namespace DesignPatterns.Behavior.Observer;

using Microsoft.Extensions.DependencyInjection;

public static class ObserverPatternExample
{
    public static void Run()
    {
        var services = new ServiceCollection();
        
        services.AddScoped<IObservable, ConcreteObservable>();
        services.AddKeyedTransient<IObserver, EmailObserver>("email");
        services.AddKeyedTransient<IObserver, SmsObserver>("sms");
        
        var serviceProvider = services.BuildServiceProvider();
        
        Console.WriteLine("---------------OBSERVER PATTERN BEGINS--------------");
        var observable = serviceProvider.GetRequiredService<IObservable>();
        var emailObserver1 = serviceProvider.GetRequiredKeyedService<IObserver>("email");
        var emailObserver2 = serviceProvider.GetRequiredKeyedService<IObserver>("email");
        var smsObserver1 = serviceProvider.GetRequiredKeyedService<IObserver>("sms");
        var smsObserver2 = serviceProvider.GetRequiredKeyedService<IObserver>("sms");
        var smsObserver3 = serviceProvider.GetRequiredKeyedService<IObserver>("sms");

        observable.Subscribe(emailObserver1);
        observable.Subscribe(emailObserver2);
        observable.Subscribe(smsObserver1);
        observable.Subscribe(smsObserver2);
        observable.Subscribe(smsObserver3);

        observable.Unsubscribe(smsObserver2);
        observable.Notify("Hi all!!!");
        Console.WriteLine("---------------OBSERVER PATTERN ENDS--------------");
    }
}