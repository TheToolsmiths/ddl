using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content.Builders
{
    public abstract class CompiledStructContentBuilderBase
    {
        public List<CompiledFieldBuilder> Fields { get; } = new List<CompiledFieldBuilder>();

        public List<CompiledStructScopeBuilder> Scopes { get; } = new List<CompiledStructScopeBuilder>();

        public CompiledFieldBuilder AddField(string name)
        {
            var builder = new CompiledFieldBuilder(name);

            this.Fields.Add(builder);

            return builder;
        }

        public CompiledStructScopeBuilder AddScope()
        {
            var builder = new CompiledStructScopeBuilder();

            this.Scopes.Add(builder);

            return builder;
        }

        public CompiledStructScopeBuilder AddConditionalScope(ConditionalExpression expression)
        {
            var builder = CompiledStructScopeBuilder.CreateConditional(expression);

            this.Scopes.Add(builder);

            return builder;
        }

        protected List<ICompiledStructItem> CreateItemsList()
        {
            var items = new List<ICompiledStructItem>();

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
