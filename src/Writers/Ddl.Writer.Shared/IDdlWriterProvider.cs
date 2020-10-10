using System.IO;

namespace TheToolsmiths.Ddl.Writer
{
    public interface IDdlWriterProvider
    {
        IWriterHandler PrepareWriteToFile(FileInfo outputFile);

        IWriterHandler PrepareWriteToConsole();
    }
}
