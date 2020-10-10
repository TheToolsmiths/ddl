using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser.Packager;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer;

namespace TheToolsmiths.Ddl.Cli.Writer
{
    public class PackageWriter
    {
        private readonly ILogger log;
        private readonly IDdlPackageWriter packageWriter;

        public PackageWriter(
            ILogger<PackageWriter> log,
            IDdlPackageWriter packageWriter)
        {
            this.log = log;
            this.packageWriter = packageWriter;
        }

        public async Task<Result> WritePackage(Package package, IWriterHandler writerHandler)
        {
            using var _ = this.log.BeginScope("Writing Package");

            var result = await writerHandler.WriteContent(async sw => await this.packageWriter.WritePackage(sw, package));

            this.log.LogInformation("Package written");

            return result;
        }
    }
}
