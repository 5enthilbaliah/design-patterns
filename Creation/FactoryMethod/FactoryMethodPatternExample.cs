namespace DesignPatterns.Creation.FactoryMethod;

using Microsoft.Extensions.DependencyInjection;

public static class FactoryMethodPatternExample
{
    public static void Run()
    {
        var services = new ServiceCollection();
        
        services.AddKeyedScoped<LogisticsBase, TruckLogistics>("truck");
        services.AddKeyedScoped<LogisticsBase, ShipLogistics>("ship");
        
        var serviceProvider = services.BuildServiceProvider();

        Console.WriteLine("---------------FACTORY METHOD PATTERN BEGINS--------------");
        var truckLogistics = serviceProvider.GetRequiredKeyedService<LogisticsBase>("truck");
        var shipLogistics = serviceProvider.GetRequiredKeyedService<LogisticsBase>("ship");

        truckLogistics.PlanDelivery();
        shipLogistics.PlanDelivery();

        Console.WriteLine("---------------FACTORY METHOD PATTERN ENDS--------------");
    }
}