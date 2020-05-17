using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public class SimpleTypeName : ITypeName
    {
        public SimpleTypeName(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }

        public bool IsGeneric => false;

        public TypeNameKind Kind => TypeNameKind.SimpleType;

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
