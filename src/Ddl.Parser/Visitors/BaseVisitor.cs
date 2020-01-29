using Antlr4.Runtime.Tree;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class BaseVisitor<TResult> : IDdlVisitor<TResult>
    {
        public virtual TResult Visit(IParseTree tree)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitChildren(IRuleNode node)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTerminal(ITerminalNode node)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitErrorNode(IErrorNode node)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFileContents(DdlParser.FileContentsContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitRootContent(DdlParser.RootContentContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitRootContentList(DdlParser.RootContentListContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitRootScope(DdlParser.RootScopeContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructScope(DdlParser.StructScopeContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitScopeHeader(DdlParser.ScopeHeaderContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypeIdentifier(DdlParser.TypeIdentifierContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitArrayTypeIdentifier(DdlParser.ArrayTypeIdentifierContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitArrayDimensionsDefinitions(DdlParser.ArrayDimensionsDefinitionsContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFixedSizeDefinition(DdlParser.FixedSizeDefinitionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitDynamicSizeDefinition(DdlParser.DynamicSizeDefinitionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitQualifiedTypeIdentifier(DdlParser.QualifiedTypeIdentifierContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypeName(DdlParser.TypeNameContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypeParameterList(DdlParser.TypeParameterListContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitNamespacePath(DdlParser.NamespacePathContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitDefStruct(DdlParser.DefStructContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitDefStructContents(DdlParser.DefStructContentsContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructField(DdlParser.StructFieldContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFieldName(DdlParser.FieldNameContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitValueInitialization(DdlParser.ValueInitializationContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructValueInitialization(DdlParser.StructValueInitializationContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFieldValueInitialization(DdlParser.FieldValueInitializationContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitAttrUseList(DdlParser.AttrUseListContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitAttrUse(DdlParser.AttrUseContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitKeyedAttrUse(DdlParser.KeyedAttrUseContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypedStructInitUse(DdlParser.TypedStructInitUseContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypedCtorInitUse(DdlParser.TypedCtorInitUseContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitNegateExpression(DdlParser.NegateExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitBinaryExpression(DdlParser.BinaryExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitParenthesisExpression(DdlParser.ParenthesisExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitSymbolExpression(DdlParser.SymbolExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitBoolLiteralExpression(DdlParser.BoolLiteralExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitCompareSymbols(DdlParser.CompareSymbolsContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitNegateSymbol(DdlParser.NegateSymbolContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitIdentifierSymbol(DdlParser.IdentifierSymbolContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitConditionalSymbolNegation(DdlParser.ConditionalSymbolNegationContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitConditionalSymbolComparison(DdlParser.ConditionalSymbolComparisonContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitIntegerLiteral(DdlParser.IntegerLiteralContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFloatLiteral(DdlParser.FloatLiteralContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitBoolLiteral(DdlParser.BoolLiteralContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStringLiteral(DdlParser.StringLiteralContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
