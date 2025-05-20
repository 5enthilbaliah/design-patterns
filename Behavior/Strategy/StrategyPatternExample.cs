namespace DesignPatterns.Behavior.Strategy;

using Microsoft.Extensions.DependencyInjection;

public static class StrategyPatternExample
{
    private static Navigator NavigatorFactory(IServiceProvider sp, string strategyName)
    {
        var strategy = sp.GetRequiredKeyedService<IRouteStrategy>(strategyName);
        return new Navigator(strategy);
    }
    
    public static void Run()
    {
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
        
        var serviceProvider = services.BuildServiceProvider();
        
        Console.WriteLine("---------------STRATEGY PATTERN BEGINS--------------");
        
        var driveNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("drive");
        var routeByDrive = driveNavigator.BuildRoute("A", "B");
        var walkNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("walk");
        var routeByWalk = walkNavigator.BuildRoute("A", "B");
        var transportNavigator = serviceProvider.GetRequiredKeyedService<INavigator>("transport");
        var routeByTransport = transportNavigator.BuildRoute("A", "B");

        var cityDuck = new Duck(new LoudQuackStrategy(), new FlappingFlightStrategy());
        var wildDuck = new Duck(new RattlingQuackStrategy(), new GlidingFlightStrategy());
        
        Console.WriteLine("<<----NAVIGATOR EXAMPLE---->>");
        Console.WriteLine($"{routeByDrive.RouteName} | {routeByWalk.RouteName} | {routeByTransport.RouteName}");

        Console.WriteLine("<<----WILD DUCK---->>");
        wildDuck.Flight();
        wildDuck.Quack();

        Console.WriteLine("<<----CITY DUCK---->>");
        cityDuck.Flight();
        cityDuck.Quack();
        
        Console.WriteLine("---------------STRATEGY PATTERN ENDS--------------");
    }
}