using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Build.Package;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer
{
    internal class DdlPackageWriter : IDdlPackageWriter
    {
        private readonly PackageItemsWriter itemsWriter;
        private readonly IServiceProvider serviceProvider;

        public DdlPackageWriter(PackageItemsWriter itemsWriter, IServiceProvider serviceProvider)
        {
            this.itemsWriter = itemsWriter;
            this.serviceProvider = serviceProvider;
        }

        public Task<Result> WritePackage(IStructuredContentWriter writer, Package package)
        {
            writer.WriteStartObject();

            {
                var result = this.WritePackageItems(writer, package);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = this.WritePackageStructure(writer, package);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            writer.WriteEndObject();

            return Task.FromResult(Result.Success);
        }

        private Result WritePackageItems(IStructuredContentWriter writer, Package package)
        {
            var context = new RootItemWriterContext(this.serviceProvider, writer);

            writer.WritePropertyName("items");

            var result = this.itemsWriter.WriteItemsCollection(context, package.Items);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private Result WritePackageStructure(IStructuredContentWriter writer, Package package)
        {
            var context = new RootScopeWriterContext(this.serviceProvider, writer);

            writer.WritePropertyName("structure");

            writer.WriteStartObject();

            writer.WriteEndObject();

            //var result = this.itemsWriter.WriteItemsCollection(context, package.Items);

            //if (result.IsError)
            //{
            //    throw new NotImplementedException();
            //}

            return Result.Success;
        }
    }
}
