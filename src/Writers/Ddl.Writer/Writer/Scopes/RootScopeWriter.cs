using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Writer.Scopes
{
    public static class RootScopeWriter
    {
        public static void WriteRootScope(IStructuredContentWriter writer, IRootScope rootScope)
        {
            writer.WriteStartObject();

            WriteRootScopeProperties(writer, rootScope);

            writer.WriteEndObject();
        }

        private static void WriteRootScopeProperties(IStructuredContentWriter writer, IRootScope rootScope)
        {
            writer.WritePropertyName("scopeContent");

            ScopeContentWriter.WriteScopeContent(writer, rootScope.Content);
        }
    }
}
