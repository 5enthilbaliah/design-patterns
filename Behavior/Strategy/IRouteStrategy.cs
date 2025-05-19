namespace DesignPatterns.Behavior.Strategy;

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