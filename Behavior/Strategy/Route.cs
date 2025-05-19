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
