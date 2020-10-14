using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Models.Build.Types.Resolution;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IScopeTypeReferenceResolver
    {
        TypeReference Resolve(TypeReference typeReference);

        TypeResolution ResolveImportPath(ImportPath importPath);
    }
}
