namespace DesignPatterns.Behavior.Strategy;

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