using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class AttributeUseListVisitor : BaseVisitor<IReadOnlyList<IAttributeUse>>
    {
        public override IReadOnlyList<IAttributeUse> VisitAttrUseList(DdlParser.AttrUseListContext context)
        {
            var attributeUses = new List<IAttributeUse>();

            foreach (var attrUseContext in context.attrUse())
            {
                var visitor = new AttributeUseVisitor();

                var structDefinition = visitor.VisitAttrUse(attrUseContext);

                attributeUses.Add(structDefinition);
            }

            return attributeUses;
        }
    }
}
