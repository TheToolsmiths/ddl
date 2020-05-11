﻿using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class FileScopeTranspiler
    {
        public static void WriteFileScope(Utf8JsonWriter writer, ConditionalRootScope conditionalScope)
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

            //    foreach (var contentItem in conditionalScope.ContentItems)
            //    {
            //        FileContentTranspiler.WriteFileContentItem(writer, contentItem);
            //    }

            //    writer.WriteEndArray();
            //}

            writer.WriteEndObject();
        }
    }
}
