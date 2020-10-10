using System.Threading.Tasks;

using TheToolsmiths.Ddl.Parser.Packager;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    public interface IDdlPackageWriter
    {
        Task<Result> WritePackage(IStructuredContentWriter writer, Package package);
    }
}
