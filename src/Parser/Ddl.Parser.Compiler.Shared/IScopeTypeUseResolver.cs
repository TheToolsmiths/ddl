using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;

namespace TheToolsmiths.Ddl.Parser.Compiler
{
    public interface IScopeTypeUseResolver
    {
        ResolvedTypeUse Resolve(TypeUse typeUse);

        TypeResolution ResolveImportPath(ImportPath importPath);
    }
}
