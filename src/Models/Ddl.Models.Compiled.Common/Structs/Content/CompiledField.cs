using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
{
    public class CompiledField : ICompiledStructItem
    {
        public CompiledField(
            string name,
            ResolvedTypeUse fieldType,
            CompiledAttributeUseCollection attributes,
            CompiledValueInitialization initialization)
        {
            this.Name = name;
            this.FieldType = fieldType;
            this.Attributes = attributes;
            this.Initialization = initialization;
        }

        public string Name { get; }

        public ResolvedTypeUse FieldType { get; }

        public CompiledAttributeUseCollection Attributes { get; }

        public CompiledValueInitialization Initialization { get; }

        public CompiledStructItemKind ItemKind => CompiledStructItemKind.Field;
    }
}
