using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public interface IKeyedAttributeUse : IAttributeUse
    {
        Identifier Key { get; }
    }
}