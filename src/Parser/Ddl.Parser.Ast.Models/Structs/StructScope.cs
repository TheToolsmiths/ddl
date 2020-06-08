﻿using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
{
    public class StructScope : IStructDefinitionItem
    {
        public StructScope(ConditionalExpression conditionalExpression, StructDefinitionContent content)
        {
            this.ConditionalExpression = conditionalExpression;
            this.Content = content;
        }

        public ConditionalExpression ConditionalExpression { get; }

        public StructDefinitionContent Content { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.Scope;
    }
}