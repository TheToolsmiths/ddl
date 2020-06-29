using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Writer.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Writer.Scopes
{
    public static class RootScopeWriter
    {
        public static void WriteRootScope(IStructuredWriter writer, IRootScope rootScope)
        {
            writer.WriteStartObject();

            WriteRootScopeProperties(writer, rootScope);

            writer.WriteEndObject();
        }

        private static void WriteRootScopeProperties(IStructuredWriter writer, IRootScope rootScope)
        {
            writer.WritePropertyName("scopeContent");

            ScopeContentWriter.WriteScopeContent(writer, rootScope.Content);
        }
    }
}
