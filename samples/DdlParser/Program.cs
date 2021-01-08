using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Ddl.SampleApplication.Shared;

using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Package;
using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Build;
using TheToolsmiths.Ddl.Parser.Compiler;
using TheToolsmiths.Ddl.Parser.Packager;
using TheToolsmiths.Ddl.Parser.TypeIndexer;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer;

namespace DdlParser
{
    public static class Program
    {
        private const string TestFilePath = "allFeatures.ddl";

        public static async Task Main()
        {
            await using var ddlServices = DdlServices.Create();

            var serviceProvider = ddlServices.ServiceProvider;

            var timer = new Stopwatch();
            timer.Start();

            // Parse all sources in the base directory
            var parseResult = await ParseSources(ddlServices);

            if (parseResult.IsError)
            {
                throw new NotImplementedException();
            }

            var astContent = parseResult.AstContent;

            // Build models from the parsed ASTs
            var buildResult = BuildContentUnit(serviceProvider, astContent);

            if (buildResult.IsError)
            {
                throw new NotImplementedException();
            }

            var contentUnit = buildResult.Value;

            // Index all model's content units
            var indexResult = IndexContentUnit(serviceProvider, contentUnit);

            if (indexResult.IsError)
            {
                throw new NotImplementedException();
            }

            var packageIndex = indexResult.Value;

            // Resolve all model's content units types
            var compileResult = CompileContentUnit(serviceProvider, contentUnit, packageIndex);

            if (compileResult.IsError)
            {
                throw new NotImplementedException();
            }

            var compiledContentUnit = compileResult.Value;

            // Resolve all model's content units types
            var packageResult = PackageContentUnits(serviceProvider, compiledContentUnit, packageIndex);

            if (packageResult.IsError)
            {
                throw new NotImplementedException();
            }

            var package = packageResult.Value;

            // Write output
            var outputResult = await WriteOutput(serviceProvider, package);

            if (outputResult.IsError)
            {
                throw new NotImplementedException();
            }

            timer.Stop();
        }

        private static async Task<ContentUnitParseResult> ParseSources(DdlServices services)
        {
            var result = await services.TextParser.ParseFromFile(new FileInfo(TestFilePath)).ConfigureAwait(false);

            if (result.IsError)
            {
                Console.WriteLine($"Error parsing '{TestFilePath}'. {result.ErrorMessage}");
            }

            Console.WriteLine($"File '{TestFilePath}' parsed");

            return result;
        }

        private static Result<ContentUnit> BuildContentUnit(
            IServiceProvider serviceProvider,
            AstContentUnit astContentUnit)
        {
            using var scope = serviceProvider.CreateScope();

            var builder = scope.ServiceProvider.GetRequiredService<IDdlContentUnitCollectionBuilder>();

            var result = builder.BuildContentUnit(astContentUnit);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private static Result<ContentUnitsTypeIndex> IndexContentUnit(
            IServiceProvider serviceProvider,
            ContentUnit contentUnit)

        {
            using var scope = serviceProvider.CreateScope();

            var typeIndexer = scope.ServiceProvider.GetRequiredService<IDdlPackageIndexer>();

            var result = typeIndexer.IndexContentUnit(contentUnit);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private static Result<CompiledContentUnit> CompileContentUnit(
            IServiceProvider serviceProvider,
            ContentUnit contentUnit,
            ContentUnitsTypeIndex contentUnitsTypeIndex)
        {
            using var scope = serviceProvider.CreateScope();

            var compiler = scope.ServiceProvider.GetRequiredService<IDdlContentUnitCollectionCompiler>();

            var compileResult = compiler.CompileContentUnit(contentUnit, contentUnitsTypeIndex);

            if (compileResult.IsError)
            {
                throw new NotImplementedException();
            }

            return compileResult;
        }

        private static Result<Package> PackageContentUnits(
            IServiceProvider serviceProvider,
            CompiledContentUnit contentUnit,
            ContentUnitsTypeIndex contentUnitsTypeIndex)
        {
            using var scope = serviceProvider.CreateScope();

            var packager = scope.ServiceProvider.GetRequiredService<IDdlContentUnitCollectionPackager>();

            var packageResult = packager.PackageContentUnit(contentUnit, contentUnitsTypeIndex);

            if (packageResult.IsError)
            {
                throw new NotImplementedException();
            }

            return packageResult;
        }

        private static async Task<Result> WriteOutput(IServiceProvider serviceProvider, Package package)
        {
            IWriterHandler writerHandler;
            {
                using var scope = serviceProvider.CreateScope();

                var writerProvider = scope.ServiceProvider.GetRequiredService<IDdlWriterProvider>();

                writerHandler = writerProvider.PrepareWriteToConsole();
            }

            // Write the package content to output
            {
                using var scope = serviceProvider.CreateScope();

                var packageWriter = scope.ServiceProvider.GetRequiredService<IDdlPackageWriter>();

                var writeResult = await writerHandler.WriteContent(packageWriter.WritePackage, package);

                if (writeResult.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = await writerHandler.WriteOutputAsync();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }
    }
}
