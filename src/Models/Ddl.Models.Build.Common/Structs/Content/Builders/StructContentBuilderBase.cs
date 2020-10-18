using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders
{
    public abstract class StructContentBuilderBase
    {
        public List<FieldBuilder> Fields { get; } = new List<FieldBuilder>();

        public List<StructScopeBuilder> Scopes { get; } = new List<StructScopeBuilder>();

        public FieldBuilder AddField(string name)
        {
            var builder = new FieldBuilder(name);

            this.Fields.Add(builder);

            return builder;
        }

        public StructScopeBuilder AddScope()
        {
            var builder = new StructScopeBuilder();

            this.Scopes.Add(builder);

            return builder;
        }

        public StructScopeBuilder AddConditionalScope(ConditionalExpression expression)
        {
            var builder = StructScopeBuilder.CreateConditional(expression);

            this.Scopes.Add(builder);

            return builder;
        }

        protected List<IStructItem> CreateItemsList()
        {
            var items = new List<IStructItem>();

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
