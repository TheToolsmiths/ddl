using System;

using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Compiled.Scopes;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Common
{
    public class ScopeContentCompiler
    {
        private readonly IRootItemCompiler itemCompiler;
        private readonly IRootScopeCompiler scopeCompiler;

        public ScopeContentCompiler(
            IRootScopeCompiler scopeCompiler,
            IRootItemCompiler itemCompiler)
        {
            this.scopeCompiler = scopeCompiler;
            this.itemCompiler = itemCompiler;
        }

        public Result<CompiledScopeContent> CompileScopeContent(IRootScopeCompileContext context, ScopeContent scopeContent)
        {
            var builder = new CompiledScopeContentBuilder();

            var updatedContext = context.AddImportPaths(context, scopeContent.Imports);

            foreach (var item in scopeContent.Items)
            {
                var result = this.CompileScopeItem(updatedContext, builder, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var childScope in scopeContent.Scopes)
            {
                var result = this.IndexScopeTypes(updatedContext, builder, childScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var content = builder.Build();

            return Result.FromValue(content);
        }

        private Result CompileScopeItem(
            IRootScopeCompileContext context,
            CompiledScopeContentBuilder builder,
            IRootItem item)
        {
            var itemContext = context.CreateItemContext();

            var result = this.itemCompiler.CompileItem(itemContext, item);

            switch (result)
            {
                case RootItemCompileError error:
                    throw new NotImplementedException();

                case RootItemCompileSuccess success:
                    builder.Items.Add(success.CompiledItem);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            return Result.Success;
        }

        private Result IndexScopeTypes(
            IRootScopeCompileContext context,
            CompiledScopeContentBuilder builder,
            IRootScope scope)
        {
            var scopeContext = context.CreateScopeContext();

            var result = this.scopeCompiler.ResolveScopeTypes(scopeContext, scope);

            switch (result)
            {
                case RootScopeCompileError error:
                    throw new NotImplementedException();

                case RootScopeCompileSuccess success:
                    builder.Scopes.Add(success.CompiledScope);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            return Result.Success;
        }
    }
}
