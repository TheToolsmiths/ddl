using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructDefinitionVisitor : BaseVisitor<StructDefinition>
    {
        public override StructDefinition VisitDefStruct(DdlParser.DefStructContext context)
        {
            IReadOnlyList<IAttributeUse> attributes;
            {
                var attrContext = context.attrUseList();

                var attributeVisitor = new AttributeUseListVisitor();

                attributes = attributeVisitor.VisitAttrUseList(attrContext);
            }

            TypeName typeName;
            {
                var typeContext = context.typeName();

                var visitor = new TypeNameVisitor();

                typeName = visitor.VisitTypeName(typeContext);
            }

            StructDefinitionContent structContent;
            {
                var defStructContents = context.defStructContents();

                if (defStructContents != null)
                {
                    var visitor = new StructDefinitionContentVisitor();

                    structContent = visitor.VisitDefStructContents(defStructContents);
                }
                else
                {
                    structContent = StructDefinitionContent.CreateEmpty();
                }
            }

            return new StructDefinition(typeName, structContent, attributes);
        }
    }
}
