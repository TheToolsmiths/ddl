using System;

using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Structs.Content.Builders
{
    public class StructDefinitionScopeBuilder : StructDefinitionContentBuilderBase
    {
        public ConditionalExpression? Expression { get; set; }

        public bool IsConditional { get; set; }

        public ScopeDefinition Build()
        {
            var items = this.CreateItemsList();

            if (this.IsConditional)
            {
                var expression = this.Expression ?? throw new NotImplementedException();

                return new ConditionalScopeDefinition(items, expression);
            }

            return new ScopeDefinition(items);
        }

        public static StructDefinitionScopeBuilder CreateConditional(ConditionalExpression expression)
        {
            return new StructDefinitionScopeBuilder().SetConditional(expression);
        }

        private StructDefinitionScopeBuilder SetConditional(ConditionalExpression expression)
        {
            this.Expression = expression;
            this.IsConditional = true;

            return this;
        }
    }
}
