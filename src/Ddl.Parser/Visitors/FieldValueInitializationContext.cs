using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class FieldValueInitializationContext : BaseVisitor<FieldValueInitialization>
    {
        public override FieldValueInitialization VisitFieldValueInitialization(
            DdlParser.FieldValueInitializationContext context)
        {
            FieldName fieldName;
            {
                var visitor = new FieldNameVisitor();

                var nameContext = context.fieldName();
                fieldName = visitor.VisitFieldName(nameContext);
            }

            ValueInitialization initialization;
            {
                var visitor = new ValueInitializationVisitor();

                var initializationContext = context.valueInitialization();
                initialization = visitor.VisitValueInitialization(initializationContext);
            }

            return new FieldValueInitialization(fieldName, initialization);
        }
    }
}
