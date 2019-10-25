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

        public virtual TResult VisitDefStruct(DdlParser.DefStructContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructField(DdlParser.StructFieldContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFieldInitialization(DdlParser.FieldInitializationContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitTypeIdent(DdlParser.TypeIdentContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitFieldIdent(DdlParser.FieldIdentContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructInitialization(DdlParser.StructInitializationContext context)
        {
            throw new System.NotImplementedException();
        }

        public virtual TResult VisitStructFieldInitialization(DdlParser.StructFieldInitializationContext context)
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
    }
}