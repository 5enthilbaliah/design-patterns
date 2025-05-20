using DesignPatterns.Behavior.Observer;
using DesignPatterns.Behavior.Strategy;
using DesignPatterns.Structural.Decorator;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddKeyedScoped<IRouteStrategy, DriveStrategy>("drive");
services.AddKeyedScoped<IRouteStrategy, WalkStrategy>("walk");
services.AddKeyedScoped<IRouteStrategy, TransportStrategy>("transport");

services.AddKeyedScoped<INavigator, Navigator>("drive", 
    (sp, strategyName) => NavigatorFactory(sp, strategyName!.ToString() ?? string.Empty));

services.AddKeyedScoped<INavigator, Navigator>("walk", 
    (sp, strategyName) => NavigatorFactory(sp, strategyName!.ToString() ?? string.Empty));

services.AddKeyedScoped<INavigator, Navigator>("transport", 
    (sp, strategyName) => NavigatorFactory(sp, strategyName!.ToString() ?? string.Empty));


services.AddScoped<IObservable, ConcreteObservable>();
services.AddKeyedTransient<IObserver, EmailObserver>("email");
services.AddKeyedTransient<IObserver, SmsObserver>("sms");


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

// Strategy pattern - Defines a family of algorithms, encapsulates each and one and makes them interchangeable
// Decouple the business logic from algorithms whose inner logic is unimportant
// We are only interested in the output of the algorithm and not the inner logic of it 
// Plug-n-play algorithms
var driveNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("drive");
var routeByDrive = driveNavigator.BuildRoute("A", "B");
var walkNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("walk");
var routeByWalk = walkNavigator.BuildRoute("A", "B");
var transportNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("transport");
var routeByTransport = transportNavigator.BuildRoute("A", "B");

var cityDuck = new Duck(new LoudQuackStrategy(), new FlappingFlightStrategy());
var wildDuck = new Duck(new RattlingQuackStrategy(), new GlidingFlightStrategy());

Console.WriteLine("---------------STRATEGY PATTERN BEGINS--------------");
Console.WriteLine("<<----NAVIGATOR EXAMPLE---->>");
Console.WriteLine($"{routeByDrive.RouteName} | {routeByWalk.RouteName} | {routeByTransport.RouteName}");

Console.WriteLine("<<----WILD DUCK---->>");
wildDuck.Flight();
wildDuck.Quack();

Console.WriteLine("<<----CITY DUCK---->>");
cityDuck.Flight();
cityDuck.Quack();
Console.WriteLine("---------------STRATEGY PATTERN ENDS--------------");

// Observer pattern - Instead of poll/pull do a push
// Define a subscription mechanism to notify objects observing a change
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


// Decorator pattern - Attach new behaviors to objects by placing these objects inside special
// wrapper objects that contain the behaviors
Console.WriteLine("---------------DECORATOR PATTERN BEGINS--------------");
var facebookNotifier = serviceProvider.GetRequiredKeyedService<INotifier>("facebook");
facebookNotifier.Send("Decorated message");

var expresso = new Expresso();
var expressoWithSoy = new SoyDecorator(expresso);
var expressoWithSoyWithCaramel = new CaramelDecorator(expressoWithSoy);
Console.WriteLine($"Total cost ${expressoWithSoyWithCaramel.TotalCost()}");


Console.WriteLine("---------------DECORATOR PATTERN ENDS--------------");



Console.ReadLine();
return;

Navigator NavigatorFactory(IServiceProvider sp, string strategyName)
{
    var strategy = sp.GetRequiredKeyedService<IRouteStrategy>(strategyName);
    return new Navigator(strategy);
}

