using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes
{
    public interface IAttributableRootScope : IRootScope
    {
        AttributeUseCollection Attributes { get; }
    }
}
