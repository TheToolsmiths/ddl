using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.Items
{
    public abstract class TypeName
    {
        protected TypeName(TypeNameIdentifier itemName)
        {
            this.ItemName = itemName;
        }

        public TypeNameIdentifier ItemName { get; }

        public abstract override string ToString();
    }
}
