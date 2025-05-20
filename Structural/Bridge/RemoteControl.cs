namespace DesignPatterns.Structural.Bridge;

public interface IDevice
{
    string Name { get; }
    bool IsEnabled();
    void Enable();
    void Disable();
    decimal GetVolume();
    void SetVolume(decimal volume);
    int GetChannel();
    void SetChannel(int channel);
}

public abstract class Device : IDevice
{
    private bool _isEnabled;
    
    public abstract string Name { get; }

    public bool IsEnabled()
    {
        return _isEnabled;
    }

    public void Enable()
    {
        _isEnabled = true;
    }

    public void Disable()
    {
        _isEnabled = false;
    }

    public abstract decimal GetVolume();

    public abstract void SetVolume(decimal volume);


    public abstract int GetChannel();

    public abstract void SetChannel(int channel);
}

public class Television : Device
{
    private decimal _volume;
    private int _channel;

    public override string Name => "Television";

    public override decimal GetVolume()
    {
        return _volume;
    }

    public override void SetVolume(decimal volume)
    {
        _volume = volume switch
        {
            >= 0 and <= 50 => volume,
            < 0 => 0,
            > 50 => 50
        };
    }

    public override int GetChannel()
    {
        return _channel;
    }

    public override void SetChannel(int channel)
    {
        _channel = channel switch
        {
            >= 0 and <= 50 => channel,
            < 0 => 0,
            > 50 => 50
        };
    }
}

public class Radio : Device
{
    private decimal _volume;
    private int _channel;
    
    public override string Name => "Radio";
    
    public override decimal GetVolume()
    {
        return _volume;
    }

    public override void SetVolume(decimal volume)
    {
        _volume = volume switch
        {
            >= 0 and <= 25 => volume,
            < 0 => 0,
            > 25 => 25
        };
    }

    public override int GetChannel()
    {
        return _channel;
    }

    public override void SetChannel(int channel)
    {
        _channel = channel switch
        {
            >= 0 and <= 25 => channel,
            < 0 => 0,
            > 25 => 25
        };
    }
}

public class RemoteControl(IDevice device)
{
    protected readonly IDevice _device = device;

    public void TogglePower()
    {
        if (_device.IsEnabled())
            _device.Disable();
        else 
            _device.Enable();
    }

    public void VolumeUp()
    {
        var currentVolume = _device.GetVolume();
        _device.SetVolume(currentVolume + 10);
        Console.WriteLine($"{_device.Name} current volume {_device.GetVolume()}");
    }
    
    public void VolumeDown()
    {
        var currentVolume = _device.GetVolume();
        _device.SetVolume(currentVolume - 10);
        Console.WriteLine($"{_device.Name} current volume {_device.GetVolume()}");
    }
}


public class AdvancedRemoteControl(IDevice device) : RemoteControl(device)
{
    public void Mute()
    {
        _device.SetVolume(0);
        Console.WriteLine($"{_device.Name} is muted");
    }
}