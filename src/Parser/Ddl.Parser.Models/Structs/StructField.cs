using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.Structs
{
    public class StructField : IStructItem
    {
        public StructField(
            Identifier name,
            ResolvedType fieldType,
            ValueInitialization initialization,
            IReadOnlyList<IAttributeUse> attributes)
        {
            this.Attributes = attributes;
            this.Initialization = initialization;
            this.FieldType = fieldType;
            this.Name = name;
        }

        public Identifier Name { get; }

        public ResolvedType FieldType { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructItemKind ItemKind => StructItemKind.FieldDefinition;
    }
}
