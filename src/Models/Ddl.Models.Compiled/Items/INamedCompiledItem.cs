using TheToolsmiths.Ddl.Models.Compiled.Types.Names;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface INamedCompiledItem : ICompiledItem
    {
        QualifiedItemTypeName TypeName { get; }
    }
}
