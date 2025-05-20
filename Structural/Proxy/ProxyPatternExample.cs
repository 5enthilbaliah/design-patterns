namespace DesignPatterns.Structural.Proxy;

using Microsoft.Extensions.DependencyInjection;

public static class ProxyPatternExample
{
    public static void Run()
    {
        var services = new ServiceCollection();
        
        services.AddKeyedScoped<IYouTubeContent, YouTubeContent>("default");
        services.AddKeyedScoped<IYouTubeContent, ChildLockYouTubeContentProxy>("child-lock-enabled", 
            (_, _) => new ChildLockYouTubeContentProxy(true));
        services.AddKeyedScoped<IYouTubeContent, ChildLockYouTubeContentProxy>("no-child-lock", 
            (_, _) => new ChildLockYouTubeContentProxy(false));
        
        var serviceProvider = services.BuildServiceProvider();
        
        Console.WriteLine("---------------PROXY PATTERN BEGINS--------------");
        var childLockContentProxy = serviceProvider.GetRequiredKeyedService<IYouTubeContent>("child-lock-enabled");
        var manager = new YouTubeManager(childLockContentProxy);

        manager.RenderListPanel();
        Console.WriteLine("---------------PROXY PATTERN ENDS--------------");
    }
}