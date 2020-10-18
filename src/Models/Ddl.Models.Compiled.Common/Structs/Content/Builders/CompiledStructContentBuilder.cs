namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content.Builders
{
    public class CompiledStructContentBuilder : CompiledStructContentBuilderBase
    {
        public CompiledStructContent Build()
        {
            var items = this.CreateItemsList();

            return new CompiledStructContent(items);
        }
    }
}
