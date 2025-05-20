namespace DesignPatterns.Structural.Decorator;

public abstract class Beverage
{
    protected abstract decimal Cost { get; }
    public abstract string Description { get; }
    
    public virtual decimal TotalCost()
    {
        return Cost;
    }
}

public class Decaf : Beverage
{
    protected override decimal Cost { get; } = 10.00m;
    public override string Description { get; } = "Decaf";
}

public class Expresso : Beverage
{
    protected override decimal Cost { get; } = 12.00m;
    public override string Description { get; } = "Expresso";
}

public abstract class AddonDecorator(Beverage beverage) : Beverage
{
    protected override decimal Cost { get; } = 0.00m;

    public override decimal TotalCost()
    {
        return Cost + beverage.TotalCost();
    }
}

public class CaramelDecorator(Beverage beverage) : AddonDecorator(beverage)
{
    protected override decimal Cost { get; } = 2.00m;
    public override string Description { get; } = "Caramel";
}

public class MilkDecorator(Beverage beverage) : AddonDecorator(beverage)
{
    public override string Description { get; } = "Milk";
}

public class SoyDecorator(Beverage beverage) : AddonDecorator(beverage)
{
    protected override decimal Cost { get; } = 1.00m;
    public override string Description { get; } = "Soy";
}