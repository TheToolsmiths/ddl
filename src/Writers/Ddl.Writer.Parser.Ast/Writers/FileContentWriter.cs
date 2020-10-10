using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class FileContentWriter
    {
        public static void WriteFileContentItem(IStructuredContentWriter writer, IAstRootItem item)
        {
            switch (item)
            {
                case ConditionalAstRootScope fileScope:
                    FileScopeWriter.WriteFileScope(writer, fileScope);
                    break;

                case StructAstDefinition structDefinition:
                    StructDefinitionWriter.WriteStructDefinition(writer, structDefinition);
                    break;

                case EnumStructAstDefinition enumStructDefinition:
                    EnumStructDefinitionWriter.WriteEnumStructDefinition(writer, enumStructDefinition);
                    break;

                case EnumAstDefinition enumDefinition:
                    EnumDefinitionWriter.WriteEnumDefinition(writer, enumDefinition);
                    break;

                case ImportAstStatement importStatement:
                    ImportStatementWriter.WriteImportStatement(writer, importStatement);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
