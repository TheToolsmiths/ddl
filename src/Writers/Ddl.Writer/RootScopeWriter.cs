using System;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
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

            throw new NotImplementedException();

            //ScopeContentWriter.WriteScopeContent(writer, rootScope.Content);
        }
    }
}
