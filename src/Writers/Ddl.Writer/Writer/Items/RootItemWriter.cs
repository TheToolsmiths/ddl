using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Writer.Items
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
