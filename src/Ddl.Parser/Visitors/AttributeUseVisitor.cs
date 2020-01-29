using System;
using TheToolsmiths.Ddl.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class AttributeUseVisitor : BaseVisitor<IAttributeUse>
    {
        public override IAttributeUse VisitAttrUse(DdlParser.AttrUseContext context)
        {
            {
                var keyedAttrUse = context.keyedAttrUse();

                if (keyedAttrUse != null)
                {
                    var visitor = new KeyedAttributeUseVisitor();

                    return visitor.VisitKeyedAttrUse(keyedAttrUse);
                }
            }

            {
                var typedStructInitUse = context.typedStructInitUse();

                if (typedStructInitUse != null)
                {
                    var visitor = new TypedStructuredInitializationUseVisitor();

                    return visitor.VisitTypedStructInitUse(typedStructInitUse);
                }
            }


            {
                var typedCtorInitUse = context.typedCtorInitUse();

                if (typedCtorInitUse != null)
                {
                    var visitor = new TypedConstructorInitializationUseVisitor();

                    return visitor.VisitTypedCtorInitUse(typedCtorInitUse);
                }
            }

            throw new NotImplementedException();
        }
    }
}
