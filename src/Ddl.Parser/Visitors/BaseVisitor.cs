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

        public virtual TResult VisitFileScope(DdlParser.FileScopeContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructScope(DdlParser.StructScopeContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypeName(DdlParser.TypeNameContext context)
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

        public virtual TResult VisitTypeIdent(DdlParser.TypeIdentContext context)
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

        public virtual TResult VisitTypedAttrUse(DdlParser.TypedAttrUseContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitConditionalExpression(DdlParser.ConditionalExpressionContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitConditionalSymbolExpression(DdlParser.ConditionalSymbolExpressionContext context)
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
    }
}
