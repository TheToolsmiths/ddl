using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content.Builders;
using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Common
{
    public class StructDefinitionContentCompiler
    {
        public Result<CompiledStructContent> Compile(IRootScopeCompileContext context, StructContent content)
        {
            var builder = new CompiledStructContentBuilder();

            var result = this.BuildScopeItems(context, builder, content.Items);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var resolvedContent = builder.Build();

            return Result.FromValue(resolvedContent);
        }

        private Result BuildScopeItems(
            IRootScopeCompileContext context,
            CompiledStructContentBuilderBase builder,
            IReadOnlyList<IStructItem> items)
        {
            foreach (var item in items)
            {
                var result = item switch
                {
                    Field field => this.BuildFieldDefinition(context, builder, field),
                    ConditionalScope scope => this.ResolveScope(context, builder, scope),
                    Scope scope => this.ResolveConditionalScope(context, builder, scope),
                    _ => throw new ArgumentOutOfRangeException(nameof(item))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result ResolveConditionalScope(IRootScopeCompileContext context, CompiledStructContentBuilderBase builder, Scope scope)
        {
            var scopeBuilder = builder.AddScope();

            this.BuildScopeItems(context, scopeBuilder, scope.Items);

            return Result.Success;
        }

        private Result ResolveScope(IRootScopeCompileContext context, CompiledStructContentBuilderBase builder, ConditionalScope scope)
        {
            var scopeBuilder = builder.AddConditionalScope(scope.ConditionalExpression);

            this.BuildScopeItems(context, scopeBuilder, scope.Items);

            return Result.Success;
        }

        private Result BuildFieldDefinition(
            IRootScopeCompileContext context,
            CompiledStructContentBuilderBase builder,
            Field field)
        {
            var fieldBuilder = builder.AddField(field.Name);

            {
                var result = context.CommonCompilers.CompileAttributes(field.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var attributes = result.Value;

                fieldBuilder.AttributeCollection = attributes;
            }

            {
                var type = context.TypeUseResolver.Resolve(field.FieldType);

                fieldBuilder.WithType(type);
            }

            {
                CompiledValueInitialization initialization;
                {
                    var result = context.CommonCompilers.CompileValueInitialization(field.Initialization);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    initialization = result.Value;
                }

                fieldBuilder.AddInitialization(initialization);
            }

            return Result.Success;
        }
    }
}
