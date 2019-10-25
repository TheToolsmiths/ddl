using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class AttributeUseListVisitor : BaseVisitor<IReadOnlyList<AttributeUse>>
    {
        public override IReadOnlyList<AttributeUse> VisitAttrUseList(DdlParser.AttrUseListContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}