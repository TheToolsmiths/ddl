using TheToolsmiths.Ddl.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public interface IAttributableRootScope : IRootScope
    {
        AttributeUseCollection Attributes { get; }
    }
}
