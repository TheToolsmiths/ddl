using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class FileScopeTranspiler
    {
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
                    FileContentTranspiler.WriteFileContentItem(writer, contentItem);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
