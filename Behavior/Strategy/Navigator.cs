namespace DesignPatterns.Behavior.Strategy;

public class Route
{
    public int Id { get;set; }
    public string RouteName { get; set; } = null!;
    public List<string> Directions { get;init; } = [];

    public static Route SpawnOne(int id, string routeName, IEnumerable<string> directions)
    {
        var route = new Route
        {
            Id = id,
            RouteName = routeName,
        };
        
        route.Directions.AddRange(directions);
        
        return route;
    }
}

public interface IRouteStrategy
{
    Route BuildRoute(string start, string end);
}

public class DriveStrategy : IRouteStrategy
{
    public Route BuildRoute(string start, string end)
    {
        return Route.SpawnOne(1, "By road drive with vehicle", [start, end]);
    }
}

public class WalkStrategy : IRouteStrategy
{
    public Route BuildRoute(string start, string end)
    {
        return Route.SpawnOne(1, "By road by walk", [start, end]);
    }
}

public class TransportStrategy : IRouteStrategy
{
    public Route BuildRoute(string start, string end)
    {
        return Route.SpawnOne(1, "By road with public transport", [start, end]);
    }
}

public interface INavigator
{
    Route BuildRoute(string start, string end);
}

public class Navigator(IRouteStrategy strategy) : INavigator
{
    public Route BuildRoute(string start, string end)
    {
        return strategy.BuildRoute(start, end);
    }
}