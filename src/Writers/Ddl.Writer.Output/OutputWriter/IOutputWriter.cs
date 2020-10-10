using System.Threading.Tasks;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer.Output.OutputWriter
{
    public interface IOutputWriter
    {
        Task<Result> WriteAsync();
    }
}
