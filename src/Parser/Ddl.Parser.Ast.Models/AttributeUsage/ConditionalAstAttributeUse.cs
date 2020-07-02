﻿using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public class ConditionalAstAttributeUse : BaseAstAttributeUse
    {
        public ConditionalAstAttributeUse(ITypeIdentifier type, ConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public ITypeIdentifier Type { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Conditional;
        
        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}