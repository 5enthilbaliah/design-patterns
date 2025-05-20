namespace DesignPatterns.Structural.Adapter;

public class RoundPeg(double radius)
{
    public virtual double Radius => radius;
}

public class RoundHole(double radius)
{
    public double Radius => radius;

    public bool Fits(RoundPeg roundPeg)
    {
        return radius >= roundPeg.Radius;
    }
}

public class SquarePeg(int width)
{
    public int Width => width;
}

public class SquarePegAdapter(SquarePeg squarePeg)
    : RoundPeg(squarePeg.Width)
{
    public override double Radius => Math.Sqrt(2) * squarePeg.Width / 2;
}