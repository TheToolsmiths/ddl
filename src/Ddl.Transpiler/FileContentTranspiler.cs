using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Structs;

namespace Ddl.Transpiler
{
    public static class FileContentTranspiler
    {
        public static void WriteFileContentItem(Utf8JsonWriter writer, IRootContentItem item)
        {
            switch (item)
            {
                case RootScope fileScope:
                    WriteFileScope(writer, fileScope);
                    break;
                case StructDefinition structDefinition:
                    StructDefinitionTranspiler.WriteStructDefinition(writer, structDefinition);
                    break;
            }
        }

        public static void WriteFileScope(Utf8JsonWriter writer, RootScope rootScope)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "file-scope");

            if (rootScope.ConditionalExpression.IsEmpty == false)
            {
                writer.WritePropertyName("condition");

                ConditionalExpressionTranspiler.WriteConditionalExpression(
                    writer,
                    rootScope.ConditionalExpression);
            }

            if (rootScope.ContentItems.Any())
            {
                writer.WriteStartArray("content");

                foreach (var contentItem in rootScope.ContentItems)
                {
                    WriteFileContentItem(writer, contentItem);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
