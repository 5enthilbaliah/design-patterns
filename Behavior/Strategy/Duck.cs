namespace DesignPatterns.Behavior.Strategy;

public interface IQuackStrategy
{
    void Quack();
}

public class LoudQuackStrategy : IQuackStrategy
{
    public void Quack()
    {
        Console.WriteLine("Loud Quack!!!! QUACK QUACK!!!");
    }
}

public class RattlingQuackStrategy : IQuackStrategy
{
    public void Quack()
    {
        Console.WriteLine("Rattling Quack!!!! Quuaaaaaaakkkkkkk!!!");
    }
}

public interface IFlightStrategy
{
    void Flight();
}

public class FlappingFlightStrategy : IFlightStrategy 
{
    public void Flight()
    {
        Console.WriteLine("Flap flap flap flap flap flap");
    }
}

public class GlidingFlightStrategy : IFlightStrategy
{
    public void Flight()
    {
        Console.WriteLine("Swoooooooossshhhhhhhhhhh.....");
    }
}

public class Duck(IQuackStrategy quackStrategy, IFlightStrategy fightingStrategy)
{
    public void Quack()
    {
        quackStrategy.Quack();
    }

    public void Flight()
    {
        fightingStrategy.Flight();
    }
}