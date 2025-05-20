namespace DesignPatterns.Structural.Adapter;

public static class AdapterPatternExample
{
    public static void Run()
    {
        Console.WriteLine("---------------Adapter PATTERN BEGINS--------------");
        var roundHole = new RoundHole(5);
        var squarePeg1 = new SquarePeg(10);
        var squarePeg2 = new SquarePeg(5);

        var squarePegAdapter1 = new SquarePegAdapter(squarePeg1);
        var squarePegAdapter2 = new SquarePegAdapter(squarePeg2);
        
        
        Console.WriteLine($"Squarepeg-1 Fits Hole - {roundHole.Fits(squarePegAdapter1)}");
        Console.WriteLine($"Squarepeg-2 Fits Hole - {roundHole.Fits(squarePegAdapter2)}");

        Console.WriteLine("---------------Adapter PATTERN ENDS--------------");
    }
}