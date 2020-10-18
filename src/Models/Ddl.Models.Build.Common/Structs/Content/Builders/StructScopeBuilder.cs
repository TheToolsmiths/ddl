using System;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders
{
    public class StructScopeBuilder : StructContentBuilderBase
    {
        public ConditionalExpression? Expression { get; set; }

        public bool IsConditional { get; set; }

        public Scope Build()
        {
            var items = this.CreateItemsList();

            if (this.IsConditional)
            {
                var expression = this.Expression ?? throw new NotImplementedException();

                return new ConditionalScope(items, expression);
            }

            return new Scope(items);
        }

        public static StructScopeBuilder CreateConditional(ConditionalExpression expression)
        {
            return new StructScopeBuilder().SetConditional(expression);
        }

        private StructScopeBuilder SetConditional(ConditionalExpression expression)
        {
            this.Expression = expression;
            this.IsConditional = true;

            return this;
        }
    }
}
