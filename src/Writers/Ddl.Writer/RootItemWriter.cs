using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    internal static class RootItemWriter
    {
        public static void WriteItem(IStructuredContentWriter writer, IRootItem item)
        {
            writer.WriteStartObject();

            writer.WriteString("type", item.GetType().Name);

            writer.WriteEndObject();
        }
    }
}
