using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Models.Imports;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class FileContentTranspiler
    {
        public static void WriteFileContentItem(Utf8JsonWriter writer, IRootContentItem item)
        {
            switch (item)
            {
                case RootScope fileScope:
                    FileScopeTranspiler.WriteFileScope(writer, fileScope);
                    break;

                case StructDefinition structDefinition:
                    StructDefinitionTranspiler.WriteStructDefinition(writer, structDefinition);
                    break;

                case EnumStructDefinition enumStructDefinition:
                    EnumStructDefinitionTranspiler.WriteEnumStructDefinition(writer, enumStructDefinition);
                    break;

                case EnumDefinition enumDefinition:
                    EnumDefinitionTranspiler.WriteEnumDefinition(writer, enumDefinition);
                    break;

                case ImportStatement importStatement:
                    ImportStatementTranspiler.WriteImportStatement(writer, importStatement);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
