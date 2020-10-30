using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Common
{
    public class AttributesCompiler
    {
        public Result<CompiledAttributeUseCollection> CompileAttributes(
            IRootScopeCompileContext context,
            AttributeUseCollection attributes)
        {
            var resolvedAttributes = new List<ICompiledAttributeUse>();

            foreach (var attribute in attributes.Items)
            {
                var result = this.CompileAttribute(context, attribute);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                resolvedAttributes.Add(result.Value);
            }

            return Result.FromValue(CompiledAttributeUseCollection.Create(resolvedAttributes));
        }

        private Result<ICompiledAttributeUse> CompileAttribute(
            IRootScopeCompileContext context,
            IAttributeUse attribute)
        {
            return attribute switch
            {
                ConditionalAttributeUse conditional => this.CompileConditional(context, conditional),
                KeyedLiteralAttributeUse keyedLiteral => this.CompileKeyedLiteral(context, keyedLiteral),
                KeyedStructInitializationAttributeUse keyedStruct => this.CompileKeyedStructInitialization(context, keyedStruct),
                KeyedTypedAttributeUse keyedTyped => this.CompileKeyedTyped(context, keyedTyped),
                TypedStructInitializationUse typedStructInitialization => this.CompileTypedStructInitialization(
                    context,
                    typedStructInitialization),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute))
            };
        }

        private Result<ICompiledAttributeUse> CompileKeyedStructInitialization(
            IRootScopeCompileContext context,
            KeyedStructInitializationAttributeUse attribute)
        {
            var result = context.CommonCompilers.CompileStructInitialization(attribute.Initialization);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var compiledInitialization = result.Value;

            var compiledAttribute = new CompiledKeyedStructInitializationAttributeUse(attribute.Key, compiledInitialization);

            return Result.FromValue<ICompiledAttributeUse>(compiledAttribute);
        }

        private Result<ICompiledAttributeUse> CompileKeyedLiteral(
            IRootScopeCompileContext context,
            KeyedLiteralAttributeUse attribute)
        {
            string key = attribute.Key;
            var literal = attribute.Literal;

            var compiledAttribute = new CompiledKeyedLiteralAttributeUse(key, literal);

            return Result.FromValue<ICompiledAttributeUse>(compiledAttribute);
        }

        private Result<ICompiledAttributeUse> CompileConditional(
            IRootScopeCompileContext context,
            ConditionalAttributeUse attribute)
        {
            var resolvedType = context.TypeUseResolver.Resolve(attribute.Type);

            var compiledAttribute = new ConditionalCompiledAttributeUse(resolvedType, attribute.ConditionalExpression);

            return Result.FromValue<ICompiledAttributeUse>(compiledAttribute);
        }

        private Result<ICompiledAttributeUse> CompileTypedStructInitialization(
            IRootScopeCompileContext context,
            TypedStructInitializationUse attribute)
        {
            var resolvedType = context.TypeUseResolver.Resolve(attribute.Type);

            var result = context.CommonCompilers.CompileStructInitialization(attribute.Initialization);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var compiledInitialization = result.Value;

            var resolvedAttribute = new CompiledTypedInitializationUse(resolvedType, compiledInitialization);

            return Result.FromValue<ICompiledAttributeUse>(resolvedAttribute);
        }

        private Result<ICompiledAttributeUse> CompileKeyedTyped(
            IRootScopeCompileContext context,
            KeyedTypedAttributeUse attribute)
        {
            var resolvedType = context.TypeUseResolver.Resolve(attribute.Type);

            var result = context.CommonCompilers.CompileStructInitialization(attribute.Initialization);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var compiledInitialization = result.Value;

            var resolvedAttribute = new CompiledKeyedTypedAttributeUse(attribute.Key, resolvedType, compiledInitialization);

            return Result.FromValue<ICompiledAttributeUse>(resolvedAttribute);
        }
    }
}
