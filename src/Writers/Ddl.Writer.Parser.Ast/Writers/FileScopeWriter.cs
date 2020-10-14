using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class FileScopeWriter
    {
        public static void WriteFileScope(IStructuredContentWriter writer, ConditionalAstRootScope conditionalScope)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "file-scope");

            if (conditionalScope.ConditionalExpression.IsEmpty == false)
            {
                writer.WritePropertyName("condition");

                ConditionalExpressionWriter.WriteConditionalExpression(
                    writer,
                    conditionalScope.ConditionalExpression);
            }

            throw new System.NotImplementedException();

            //if (conditionalScope.ContentItems.Any())
            //{
            //    writer.WriteStartArray("content");

            //    foreach (var item in conditionalScope.ContentItems)
            //    {
            //        FileContentWriter.WriteFileContentItem(writer, item);
            //    }

            //    writer.WriteEndArray();
            //}

            writer.WriteEndObject();
        }
    }
}
