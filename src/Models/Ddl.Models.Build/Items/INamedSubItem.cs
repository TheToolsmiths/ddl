using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Items
{
    public interface INamedSubItem : ISubItem
    {
        TypeNameIdentifier SubItemName { get; }
    }

    public interface ISimpleNamedSubItem : INamedSubItem
    {
        new SimpleTypeNameIdentifier SubItemName { get; }
    }
}
