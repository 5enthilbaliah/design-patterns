namespace DesignPatterns.Structural.Proxy;

public interface IYouTubeContent
{
    IEnumerable<string> ListVideos();
}

public class YouTubeContent : IYouTubeContent
{
    public virtual IEnumerable<string> ListVideos()
    {
        for (var i = 0; i < 10; i++)
        {
            yield return "https://www.youtube.com/watch?v=" + i;
        }
    }
}

public class ChildLockYouTubeContentProxy(bool isChildLock) : YouTubeContent
{
    // NOTE: this is a composition not aggregation
    private readonly IYouTubeContent _youTubeContent = new YouTubeContent();

    public override IEnumerable<string> ListVideos()
    {
        return isChildLock ? _youTubeContent.ListVideos().Skip(5) : _youTubeContent.ListVideos();
    }
}


public class YouTubeManager(IYouTubeContent youTubeContent)
{
    public void RenderListPanel()
    {
        foreach (var listVideo in youTubeContent.ListVideos())
        {
            Console.WriteLine(listVideo);
        }
    }
}