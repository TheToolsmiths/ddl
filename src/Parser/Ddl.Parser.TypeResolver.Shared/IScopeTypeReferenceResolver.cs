using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Types.Resolution;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IScopeTypeReferenceResolver
    {
        TypeReference Resolve(TypeReference typeReference);

        TypeResolution ResolveImportPath(ImportPath importPath);
    }
}
