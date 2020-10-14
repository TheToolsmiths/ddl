using TheToolsmiths.Ddl.Models.Build.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes
{
    public interface IAttributableRootScope : IRootScope
    {
        AttributeUseCollection Attributes { get; }
    }
}
