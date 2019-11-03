using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructFieldVisitor : BaseVisitor<FieldDefinition>
    {
        public override FieldDefinition VisitStructField(DdlParser.StructFieldContext context)
        {
            FieldName name;
            {
                var fieldNameContext = context.fieldName();

                var visitor = new FieldNameVisitor();

                name = visitor.VisitFieldName(fieldNameContext);
            }

            TypeIdentifier type;
            {
                var typeIdentContext = context.typeIdent();

                var visitor = new TypeIdentifierVisitor();

                type = visitor.VisitTypeIdent(typeIdentContext);
            }

            ValueInitialization initialization;
            {
                var initializationContext = context.valueInitialization();

                var visitor = new ValueInitializationVisitor();

                initialization = visitor.VisitValueInitialization(initializationContext);
            }

            IReadOnlyList<IAttributeUse> attributes;
            {
                var attrContext = context.attrUseList();

                var attributeVisitor = new AttributeUseListVisitor();

                attributes = attributeVisitor.VisitAttrUseList(attrContext);
            }

            return new FieldDefinition(name, type, initialization, attributes);
        }
    }
}
