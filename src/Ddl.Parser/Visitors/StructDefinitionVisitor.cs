using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructDefinitionVisitor : BaseVisitor<StructDefinition>
    {
        public override StructDefinition VisitDefStruct(DdlParser.DefStructContext context)
        {
            {
                var attrContext = context.attrUseList();
                var attributeVisitor = new AttributeUseListVisitor();

                var attributes = attributeVisitor.VisitAttrUseList(attrContext);
            }


            return base.VisitDefStruct(context);
        }
    }
}