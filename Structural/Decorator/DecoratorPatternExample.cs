namespace DesignPatterns.Structural.Decorator;

using Microsoft.Extensions.DependencyInjection;

public static class DecoratorPatternExample
{
    public static void Run()
    {
        var services = new ServiceCollection();
        
        services.AddKeyedScoped<INotifier, DefaultNotifier>("default");
        services.AddKeyedScoped<INotifier, SmsDecorator>("sms", (sp, _) =>
        {
            var defaultNotifier = sp.GetRequiredKeyedService<INotifier>("default");
            return new SmsDecorator(defaultNotifier);
        });
        services.AddKeyedScoped<INotifier, FacebookDecorator>("facebook", (sp, _) =>
        {
            var defaultNotifier = sp.GetRequiredKeyedService<INotifier>("sms");
            return new FacebookDecorator(defaultNotifier);
        });
        
        var serviceProvider = services.BuildServiceProvider();
        
        Console.WriteLine("---------------DECORATOR PATTERN BEGINS--------------");
        var facebookNotifier = serviceProvider.GetRequiredKeyedService<INotifier>("facebook");
        facebookNotifier.Send("Decorated message");

        var expresso = new Expresso();
        var expressoWithSoy = new SoyDecorator(expresso);
        var expressoWithSoyWithCaramel = new CaramelDecorator(expressoWithSoy);
        Console.WriteLine($"Total cost ${expressoWithSoyWithCaramel.TotalCost()}");


        Console.WriteLine("---------------DECORATOR PATTERN ENDS--------------");
    }
}