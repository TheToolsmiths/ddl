using System;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common
{
    public class CommonScopeWriters : CommonWriters, ICommonScopeWriters
    {
        public CommonScopeWriters(IServiceProvider provider, IRootScopeWriterContext context)
            : base(provider, context)
        {
        }

        public Result WriteScopeContent(ScopeContent scopeContent)
        {
            throw new NotImplementedException();
        }
    }
}
