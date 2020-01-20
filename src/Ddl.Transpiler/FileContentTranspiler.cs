using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Structs;

namespace Ddl.Transpiler
{
    public static class FileContentTranspiler
    {
        public static void WriteFileContentItem(Utf8JsonWriter writer, IFileContentItem item)
        {
            switch (item)
            {
                case FileScope fileScope:
                    WriteFileScope(writer, fileScope);
                    break;
                case StructDefinition structDefinition:
                    StructDefinitionTranspiler.WriteStructDefinition(writer, structDefinition);
                    break;
            }
        }

        public static void WriteFileScope(Utf8JsonWriter writer, FileScope fileScope)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "file-scope");

            if (fileScope.ConditionalExpression.IsEmpty == false)
            {
                writer.WritePropertyName("condition");

                ConditionalExpressionTranspiler.WriteConditionalExpression(
                    writer,
                    fileScope.ConditionalExpression);
            }

            if (fileScope.Content.Items.Any())
            {
                writer.WriteStartArray("content");

                foreach (var contentItem in fileScope.Content.Items)
                {
                    WriteFileContentItem(writer, contentItem);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
