namespace DesignPatterns.Creation.FactoryMethod;

public interface ITransport
{
    void Deliver();
}

public class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Deliver via ship");
    }
}

public class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Deliver via truck");
    }
}

public abstract class LogisticsBase
{
    protected abstract ITransport CreateTransport();

    public void PlanDelivery()
    {
        var transport = CreateTransport();
        transport.Deliver();
    }
}

public class ShipLogistics : LogisticsBase
{
    protected override ITransport CreateTransport()
    {
        return new Ship();
    }
}

public class TruckLogistics : LogisticsBase
{
    protected override ITransport CreateTransport()
    {
        return new Truck();
    }
}