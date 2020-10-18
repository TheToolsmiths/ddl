using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Build.Enums;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Enums;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Parser.Compiler.Contexts;
using TheToolsmiths.Ddl.Parser.Compiler.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Compiler.Implementations
{
    internal class EnumDefinitionCompiler : IItemCompiler<EnumDefinition>
    {
        public RootItemCompileResult CompileItem(IRootItemCompileContext itemContext, EnumDefinition item)
        {
            var updatedItemContext = itemContext.AddTypeNameInfoToContext(item.TypeName);

            var builder = new RootItemResultBuilder();

            CompiledAttributeUseCollection attributes;
            {
                var result = updatedItemContext.CommonCompilers.CompileAttributes(item.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            IReadOnlyList<CompiledEnumConstant> constants;
            {
                var result = this.CompileConstants(updatedItemContext, item.Constants, item.TypeName);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                constants = result.Value;
            }

            var typeNameResolution = updatedItemContext.TypeNameResolver.Resolve(item.TypeName);

            builder.Item = new CompiledEnumDefinition(item.ItemId, typeNameResolution, constants, attributes);

            return builder.CreateSuccessResult();
        }

        private Result<IReadOnlyList<CompiledEnumConstant>> CompileConstants(
            IRootItemCompileContext itemContext,
            IReadOnlyList<EnumConstantDefinition> constants,
            ItemTypeName itemName)
        {
            var resolvedConstants = new List<CompiledEnumConstant>();

            foreach (var constantDefinition in constants)
            {
                var result = this.CompileConstant(itemContext, constantDefinition, itemName);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                resolvedConstants.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<CompiledEnumConstant>>(resolvedConstants);
        }

        private Result<CompiledEnumConstant> CompileConstant(
            IRootItemCompileContext itemContext,
            EnumConstantDefinition constant,
            ItemTypeName itemName)
        {
            CompiledAttributeUseCollection attributes;
            {
                var result = itemContext.CommonCompilers.CompileAttributes(constant.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var subItemName = new SubItemTypeName(itemName.ItemName, constant.SubItemName);

            var qualifiedName = itemContext.TypeNameResolver.Resolve(subItemName);

            var resolvedConstant = new CompiledEnumConstant(constant.SubItemId, qualifiedName, attributes, constant.Value);

            return Result.FromValue(resolvedConstant);
        }
    }
}
