using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Ast.Models.Imports;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class FileContentTranspiler
    {
        public static void WriteFileContentItem(Utf8JsonWriter writer, IAstRootItem item)
        {
            switch (item)
            {
                case ConditionalAstRootScope fileScope:
                    FileScopeTranspiler.WriteFileScope(writer, fileScope);
                    break;

                case StructAstDefinition structDefinition:
                    StructDefinitionTranspiler.WriteStructDefinition(writer, structDefinition);
                    break;

                case EnumStructAstDefinition enumStructDefinition:
                    EnumStructDefinitionTranspiler.WriteEnumStructDefinition(writer, enumStructDefinition);
                    break;

                case EnumAstDefinition enumDefinition:
                    EnumDefinitionTranspiler.WriteEnumDefinition(writer, enumDefinition);
                    break;

                case ImportAstStatement importStatement:
                    ImportStatementTranspiler.WriteImportStatement(writer, importStatement);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
