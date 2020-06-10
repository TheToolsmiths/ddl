using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;

namespace TheToolsmiths.Ddl.Parser.Build.BuildPhase
{
    public class RootItemBuilder
    {
        //private readonly ContentUnitEntityResolverProvider resolverProvider;

        //public RootItemBuilder(ContentUnitEntityResolverProvider resolverProvider)
        //{
        //    this.resolverProvider = resolverProvider;
        //}

        public Result BuildItem(IRootItemBuildContext context, IAstRootItem item)
        {
            throw new NotImplementedException();

            //var result = item switch
            //{
            //    EnumAstDefinition enumDefinition => this.resolverProvider.CreateEnumDefinitionResolver()
            //        .BuildItem(context, enumDefinition),

            //    EnumStructAstDefinition enumStructDefinition => this.resolverProvider.CreateEnumStructDefinitionResolver()
            //        .BuildItem(context, enumStructDefinition),

            //    ImportStatement importStatement => this.resolverProvider.CreateImportStatementResolver()
            //        .BuildItem(context, importStatement),

            //    StructAstDefinition structDefinition => this.resolverProvider.CreateStructDefinitionResolver()
            //        .BuildItem(context, structDefinition),

            //    _ => throw new ArgumentOutOfRangeException(nameof(item))
            //};

            //if (result.IsError)
            //{
            //    throw new NotImplementedException();
            //}

            //return Result.Success;
        }
    }
}
