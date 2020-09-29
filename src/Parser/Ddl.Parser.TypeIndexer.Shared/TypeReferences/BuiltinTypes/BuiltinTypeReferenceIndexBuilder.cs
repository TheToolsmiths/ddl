namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences.BuiltinTypes
{
    public class BuiltinTypeReferenceIndexBuilder
    {
        public BuiltinTypeReferenceResolver Build()
        {
            // TODO: Consider possibility of configurable builtin types?
            return new BuiltinTypeReferenceResolver();
        }
    }
}
