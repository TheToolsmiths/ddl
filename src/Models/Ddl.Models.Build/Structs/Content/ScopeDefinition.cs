using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
{
    public class ScopeDefinition : IStructDefinitionItem
    {
        public ScopeDefinition(IReadOnlyList<IStructDefinitionItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IStructDefinitionItem> Items { get; }

        public StructDefinitionItemKind ItemKind => StructDefinitionItemKind.Scope;
    }
}
