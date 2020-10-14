using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders
{
    public abstract class StructDefinitionContentBuilderBase
    {
        public List<StructDefinitionFieldBuilder> Fields { get; } = new List<StructDefinitionFieldBuilder>();

        public List<StructDefinitionScopeBuilder> Scopes { get; } = new List<StructDefinitionScopeBuilder>();

        public StructDefinitionFieldBuilder AddField(string name)
        {
            var builder = new StructDefinitionFieldBuilder(name);

            this.Fields.Add(builder);

            return builder;
        }

        public StructDefinitionScopeBuilder AddScope()
        {
            var builder = new StructDefinitionScopeBuilder();

            this.Scopes.Add(builder);

            return builder;
        }

        public StructDefinitionScopeBuilder AddConditionalScope(ConditionalExpression expression)
        {
            var builder = StructDefinitionScopeBuilder.CreateConditional(expression);

            this.Scopes.Add(builder);

            return builder;
        }

        protected List<IStructDefinitionItem> CreateItemsList()
        {
            var items = new List<IStructDefinitionItem>();

            foreach (var fieldBuilder in this.Fields)
            {
                items.Add(fieldBuilder.Build());
            }

            foreach (var scopeBuilder in this.Scopes)
            {
                items.Add(scopeBuilder.Build());
            }

            return items;
        }
    }
}
