﻿using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class ConditionalRootScope : RootScope
    {
        public ConditionalRootScope(
            ConditionalExpression conditionalExpression,
            ScopeContent content)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public override ContentUnitScopeType ScopeType => ContentUnitScopeType.RootScope;

        public ConditionalExpression ConditionalExpression { get; }
    }
}