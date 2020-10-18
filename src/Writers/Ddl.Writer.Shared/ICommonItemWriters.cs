using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonItemWriters : ICommonWriters
    {
        Result WriteStructDefinitionContent(StructContent content);
    }
}
