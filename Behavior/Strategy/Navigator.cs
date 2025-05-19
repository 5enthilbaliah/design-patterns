namespace DesignPatterns.Behavior.Strategy;

public interface INavigator
{
    Route BuildRoute(string start, string end);
}

public class Navigator(IRouteStrategy strategy) : INavigator
{
    private readonly IRouteStrategy _strategy = strategy;
    
    public Route BuildRoute(string start, string end)
    {
        return _strategy.BuildRoute(start, end);
    }
}