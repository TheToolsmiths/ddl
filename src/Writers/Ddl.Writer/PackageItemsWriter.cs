using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer
{
    internal class PackageItemsWriter
    {
        private readonly PackageItemWriter packageItemWriter;

        public PackageItemsWriter(PackageItemWriter packageItemWriter)
        {
            this.packageItemWriter = packageItemWriter;
        }

        public Result WriteItemsCollection(ICompiledItemWriterContext context, PackageItemsCollection itemsCollection)
        {
            context.Writer.WriteStartArray();

            var result = this.WriteItems(context, itemsCollection.Items);

            if (result.IsError)
            {
                throw new System.NotImplementedException();
            }

            context.Writer.WriteEndArray();

            return Result.Success;
        }

        private Result WriteItems(ICompiledItemWriterContext context, IReadOnlyList<PackageItem> items)
        {
            foreach (var packageItem in items)
            {
                var result = this.packageItemWriter.WriteItem(context, packageItem);

                if (result.IsError)
                {
                    throw new System.NotImplementedException();
                }
            }

            return Result.Success;
        }
    }
}
