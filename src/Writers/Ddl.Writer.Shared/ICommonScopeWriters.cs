using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    public interface ICommonScopeWriters : ICommonWriters
    {
        Result WriteScopeContent(ScopeContent scopeContent);
    }
}