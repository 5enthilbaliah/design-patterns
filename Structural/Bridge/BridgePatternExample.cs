namespace DesignPatterns.Structural.Bridge;

using Microsoft.Extensions.DependencyInjection;

public static class BridgePatternExample
{
    public static void Run()
    {
        var services = new ServiceCollection();
        services.AddKeyedScoped<IDevice, Radio>("radio");
        services.AddKeyedScoped<IDevice, Television>("television");

        services.AddKeyedScoped<RemoteControl, RemoteControl>("radio-normal", (sp, _) =>
        {
            var radio = sp.GetRequiredKeyedService<IDevice>("radio");
            return new RemoteControl(radio);
        });
        services.AddKeyedScoped<AdvancedRemoteControl, AdvancedRemoteControl>("tv-advanced", (sp, _) =>
        {
            var radio = sp.GetRequiredKeyedService<IDevice>("television");
            return new AdvancedRemoteControl(radio);
        });
        
        var serviceProvider = services.BuildServiceProvider();
        
        Console.WriteLine("---------------BRIDGE PATTERN BEGINS--------------");
        var normalRemoteForRadio = serviceProvider.GetRequiredKeyedService<RemoteControl>("radio-normal");
        var advRemoteForTv = serviceProvider.GetRequiredKeyedService<AdvancedRemoteControl>("tv-advanced");

        normalRemoteForRadio.VolumeUp();
        advRemoteForTv.Mute();

        Console.WriteLine("---------------BRIDGE PATTERN ENDS--------------");
    }
}