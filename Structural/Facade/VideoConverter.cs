namespace DesignPatterns.Structural.Facade;

using System.Text;

public class VideoFile(string fileName)
{
    public string FileName => fileName;
}

public class BaseCompressionCodec
{
    public virtual byte[] Read(VideoFile file)
    {
        return Encoding.ASCII.GetBytes($"BASE::{file.FileName}");
    }
}

public class OggCompressionCodec : BaseCompressionCodec
{
    public override byte[] Read(VideoFile file)
    {
        return Encoding.ASCII.GetBytes($"OGG::{file.FileName}");
    }
}

public class MPEG4CompressionCodec : BaseCompressionCodec
{
    public override byte[] Read(VideoFile file)
    {
        return Encoding.ASCII.GetBytes($"MPEG::{file.FileName}");
    }
}

public class BitrateReader
{
    public byte[] Read(string fileName, BaseCompressionCodec codec)
    {
        return codec.Read(new VideoFile(fileName));
    }

    public byte[] Convert(byte[] buffer, BaseCompressionCodec codec)
    {
        var fileName = Encoding.ASCII.GetString(buffer);
        return codec.Read(new VideoFile($"Converted-{fileName}"));
    }
}

public class VideoConverterFacade
{
    public string Convert(string fileName, string format)
    {
        var bitRateReader = new BitrateReader();
        var baseCodec = new BaseCompressionCodec();
        var baseResult = bitRateReader.Read(fileName, baseCodec);
        
        BaseCompressionCodec destinationCodec = format == "mp4" ? new MPEG4CompressionCodec() : new OggCompressionCodec();
        var compressedResult = bitRateReader.Convert(baseResult, destinationCodec);

        return Encoding.ASCII.GetString(compressedResult);
    }
}