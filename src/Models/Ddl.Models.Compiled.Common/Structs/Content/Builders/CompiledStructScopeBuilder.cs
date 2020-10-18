using System;

using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content.Builders
{
    public class CompiledStructScopeBuilder : CompiledStructContentBuilderBase
    {
        public ConditionalExpression? Expression { get; set; }

        public bool IsConditional { get; set; }

        public CompiledStructScope Build()
        {
            var items = this.CreateItemsList();

            if (this.IsConditional)
            {
                var expression = this.Expression ?? throw new NotImplementedException();

                return new ConditionalCompiledStructScope(items, expression);
            }

            return new CompiledStructScope(items);
        }

        public static CompiledStructScopeBuilder CreateConditional(ConditionalExpression expression)
        {
            return new CompiledStructScopeBuilder().SetConditional(expression);
        }

        private CompiledStructScopeBuilder SetConditional(ConditionalExpression expression)
        {
            this.Expression = expression;
            this.IsConditional = true;

            return this;
        }
    }
}
