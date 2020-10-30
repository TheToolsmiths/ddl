using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonItemWriters : ICommonWriters
    {
        Result WriteStructDefinitionContent(CompiledStructContent content);
    }
}
