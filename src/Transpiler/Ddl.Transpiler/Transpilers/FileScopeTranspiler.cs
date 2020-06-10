using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class FileScopeTranspiler
    {
        public static void WriteFileScope(Utf8JsonWriter writer, ConditionalAstRootScope conditionalScope)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "file-scope");

            if (conditionalScope.ConditionalExpression.IsEmpty == false)
            {
                writer.WritePropertyName("condition");

                ConditionalExpressionTranspiler.WriteConditionalExpression(
                    writer,
                    conditionalScope.ConditionalExpression);
            }

            throw new System.NotImplementedException();

            //if (conditionalScope.ContentItems.Any())
            //{
            //    writer.WriteStartArray("content");

            //    foreach (var item in conditionalScope.ContentItems)
            //    {
            //        FileContentTranspiler.WriteFileContentItem(writer, item);
            //    }

            //    writer.WriteEndArray();
            //}

            writer.WriteEndObject();
        }
    }
}
