using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Common
{
    public class ValueInitializationCompiler
    {
        public Result<CompiledValueInitialization> Compile(
            IRootScopeCompileContext context,
            ValueInitialization initialization)
        {
            return initialization switch
            {
                EmptyInitialization _ => this.CompileEmpty(context),

                LiteralInitialization literal => this.CompileLiteral(context, literal),

                StructInitialization structInitialization => this
                    .CompileStructInitialization(context, structInitialization)
                    .As<CompiledValueInitialization>(),

                TypedStructInitialization typedStructInitialization => this.CompileTyped(
                    context,
                    typedStructInitialization),

                _ => throw new ArgumentOutOfRangeException(nameof(initialization))
            };
        }

        public Result<CompiledStructInitialization> CompileStructInitialization(
            IRootScopeCompileContext context,
            StructInitialization structInitialization)
        {
            var compiledFields = new List<CompiledFieldInitialization>();

            foreach (var fieldInitialization in structInitialization.Fields)
            {
                var result = this.Compile(context, fieldInitialization.Initialization);

                var compiledField = new CompiledFieldInitialization(fieldInitialization.Name, result.Value);

                compiledFields.Add(compiledField);
            }

            var compiledInitialization = new CompiledStructInitialization(compiledFields);

            return Result.FromValue(compiledInitialization);
        }

        private Result<CompiledValueInitialization> CompileTyped(
            IRootScopeCompileContext context,
            TypedStructInitialization typedStruct)
        {
            var resolvedType = context.TypeUseResolver.Resolve(typedStruct.Type);

            var result = this.CompileStructInitialization(context, typedStruct.Initialization);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var initialization = result.Value;
            var compiledTyped = new CompiledTypedStructInitialization(resolvedType, initialization);

            return Result.FromValue<CompiledValueInitialization>(compiledTyped);
        }

        private Result<CompiledValueInitialization> CompileLiteral(
            IRootScopeCompileContext context,
            LiteralInitialization literal)
        {
            var compiledLiteral = new CompiledLiteralInitialization(literal.Literal);

            return Result.FromValue<CompiledValueInitialization>(compiledLiteral);
        }

        private Result<CompiledValueInitialization> CompileEmpty(IRootScopeCompileContext context)
        {
            return Result.FromValue<CompiledValueInitialization>(new CompiledEmptyInitialization());
        }
    }
}
