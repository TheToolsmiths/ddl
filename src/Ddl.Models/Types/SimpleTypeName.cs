using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Types
{
    public class SimpleTypeName : ITypeName
    {
        public SimpleTypeName(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }

        public bool IsGeneric => false;

        public TypeNameType Type => TypeNameType.SimpleType;

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
