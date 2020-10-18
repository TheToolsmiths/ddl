namespace TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders
{
    public class StructContentBuilder : StructContentBuilderBase
    {
        public StructContent Build()
        {
            var items = this.CreateItemsList();

            return new StructContent(items);
        }
    }
}
