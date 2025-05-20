namespace DesignPatterns.Structural.Facade;

public static class FacadePatternExample
{
    public static void Run()
    {
        var videoConverter = new VideoConverterFacade();
        
        Console.WriteLine("---------------FACADE PATTERN BEGINS--------------");

        var result = videoConverter.Convert("test-file.mp4", "mp4");
        Console.WriteLine(result);

        Console.WriteLine("---------------FACADE PATTERN ENDS--------------");
    }
}