using DesignPatterns.Behavior.Strategy;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddKeyedScoped<IRouteStrategy, DriveStrategy>("drive");
services.AddKeyedScoped<IRouteStrategy, WalkStrategy>("walk");
services.AddKeyedScoped<IRouteStrategy, TransportStrategy>("transport");

Navigator NavigatorFactory(IServiceProvider sp, string strategyName)
{
    var strategy = sp.GetRequiredKeyedService<IRouteStrategy>(strategyName);
    return new Navigator(strategy);
}

services.AddKeyedScoped<INavigator, Navigator>("drive", 
    (sp, strategyName) => NavigatorFactory(sp, strategyName!.ToString() ?? string.Empty));

services.AddKeyedScoped<INavigator, Navigator>("walk", 
    (sp, strategyName) => NavigatorFactory(sp, strategyName!.ToString() ?? string.Empty));

services.AddKeyedScoped<INavigator, Navigator>("transport", 
    (sp, strategyName) => NavigatorFactory(sp, strategyName!.ToString() ?? string.Empty));


var serviceProvider = services.BuildServiceProvider();

// Strategy pattern - Defines a family of algorithms, encapsulates each and one and makes them interchangeable
// Decouple the business logic from algorithms whose inner logic is unimportant
// We are only interested in the output of the algorithm and not the inner logic of it 
var driveNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("drive");
var routeByDrive = driveNavigator.BuildRoute("A", "B");
var walkNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("walk");
var routeByWalk = walkNavigator.BuildRoute("A", "B");
var transportNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("transport");
var routeByTransport = transportNavigator.BuildRoute("A", "B");

Console.WriteLine($"{routeByDrive.RouteName} | {routeByWalk.RouteName} | {routeByTransport.RouteName}");

Console.ReadLine();

