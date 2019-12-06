using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class TypedAttributeUse : BaseTypedAttributeUse
    {
        public TypedAttributeUse(TypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override AttributeUseType UseType => AttributeUseType.Typed;

        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
