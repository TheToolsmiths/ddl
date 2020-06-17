﻿namespace TheToolsmiths.Ddl.Models.Structs.Content.Builders
{
    public class StructDefinitionContentBuilder : StructDefinitionContentBuilderBase
    {
        public StructDefinitionContent Build()
        {
            var items = this.CreateItemsList();

            return new StructDefinitionContent(items);
        }
    }
}
