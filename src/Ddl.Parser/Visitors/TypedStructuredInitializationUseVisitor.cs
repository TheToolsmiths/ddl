using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypedStructuredInitializationUseVisitor : BaseVisitor<ITypedAttributeUse>
    {
        public override ITypedAttributeUse VisitTypedStructInitUse(DdlParser.TypedStructInitUseContext context)
        {
            ITypeIdentifier type;
            {
                var typeIdentifierContext = context.typeIdentifier();

                var visitor = new TypeIdentifierVisitor();

                type = visitor.VisitTypeIdentifier(typeIdentifierContext);
            }

            StructValueInitialization initialization;
            {
                var structInitContext = context.structValueInitialization();

                var visitor = new StructValueInitializationVisitor();

                initialization = visitor.VisitStructValueInitialization(structInitContext);
            }

            return new TypedStructInitializationUse(type, initialization);
        }
    }
}