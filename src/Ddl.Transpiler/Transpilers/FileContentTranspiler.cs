using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Imports;
using TheToolsmiths.Ddl.Models.Structs;

namespace Ddl.Transpiler.Transpilers
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
