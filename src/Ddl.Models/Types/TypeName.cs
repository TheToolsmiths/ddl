using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class TypeName
    {
        public TypeName(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
