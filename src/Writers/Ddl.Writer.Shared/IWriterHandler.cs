using System;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    public interface IWriterHandler : IAsyncDisposable
    {
        Task<Result> WriteOutputAsync();

        Task<Result> WriteContent(Func<IStructuredContentWriter, Task<Result>> contentWriterFunc);

        Task<Result> WriteContent<TContext>(Func<IStructuredContentWriter, TContext, Task<Result>> contentWriterFunc, TContext context);
    }
}
