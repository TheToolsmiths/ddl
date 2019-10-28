using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class AttributeUseVisitor : BaseVisitor<AttributeUse>
    {
        public override AttributeUse VisitAttrUse(DdlParser.AttrUseContext context)
        {
            return base.VisitAttrUse(context);
        }
    }
}