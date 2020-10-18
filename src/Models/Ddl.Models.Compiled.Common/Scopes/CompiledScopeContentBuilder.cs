using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public class CompiledScopeContentBuilder
    {
        public CompiledScopeContent Build()
        {
            return new CompiledScopeContent(this.Items, this.Scopes);
        }

        public List<ICompiledItem> Items { get; } = new List<ICompiledItem>();

        public List<ICompiledScope> Scopes { get; } = new List<ICompiledScope>();
    }
}
