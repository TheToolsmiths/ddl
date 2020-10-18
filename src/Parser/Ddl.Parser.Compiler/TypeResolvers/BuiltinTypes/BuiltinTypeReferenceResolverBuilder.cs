namespace TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers.BuiltinTypes
{
    public class BuiltinTypeReferenceResolverBuilder
    {
        public BuiltinTypeReferenceResolver Build()
        {
            // TODO: Consider possibility of configurable builtin types?
            return new BuiltinTypeReferenceResolver();
        }
    }
}
