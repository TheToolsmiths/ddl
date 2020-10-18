using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Compilers;
using TheToolsmiths.Ddl.Cli.Packagers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.TypeIndexers;
using TheToolsmiths.Ddl.Cli.Writer;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Package;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer;

namespace TheToolsmiths.Ddl.Cli.CommandHandlers
{
    internal static class PackageCommandHandler
    {
        public static async Task HandlePackageDirectory(
            IHost host,
            DirectoryInfo baseDirectory,
            string glob,
            FileInfo? outputFile)
        {
            var timer = new Stopwatch();
            timer.Start();

            var serviceProvider = host.Services;

            // Parse all sources in the base directory
            var lexerResult = await ParseSources(serviceProvider, baseDirectory, glob);

            if (lexerResult.IsError)
            {
                throw new NotImplementedException();
            }

            var astContentUnits = lexerResult.Value;

            // Build models from the parsed ASTs
            var buildResult = BuildContentUnits(serviceProvider, astContentUnits);

            if (buildResult.IsError)
            {
                throw new NotImplementedException();
            }

            var contentUnits = buildResult.Value;

            // Index all model's content units
            var indexResult = IndexContentUnits(serviceProvider, contentUnits);

            if (indexResult.IsError)
            {
                throw new NotImplementedException();
            }

            var packageIndex = indexResult.Value;

            // Resolve all model's content units types
            var compileResult = CompileContentUnits(serviceProvider, contentUnits, packageIndex);

            if (compileResult.IsError)
            {
                throw new NotImplementedException();
            }

            var compiledContentUnits = compileResult.Value;

            // Resolve all model's content units types
            var packageResult = PackageContentUnits(serviceProvider, compiledContentUnits, packageIndex);

            if (packageResult.IsError)
            {
                throw new NotImplementedException();
            }

            var package = packageResult.Value;

            // Prepare output
            var fooResult = PrepareOutput(serviceProvider, outputFile);

            if (fooResult.IsError)
            {
                throw new NotImplementedException();
            }

            await using var writerFoo = fooResult.Value;

            // Write the package content to output
            var writeResult = await WritePackageContent(serviceProvider, package, writerFoo);

            if (writeResult.IsError)
            {
                throw new NotImplementedException();
            }

            // Write output
            var outputResult = await WriteOutput(serviceProvider, writerFoo);

            if (outputResult.IsError)
            {
                throw new NotImplementedException();
            }

            timer.Stop();
        }

        private static async Task<Result<IReadOnlyList<AstContentUnit>>> ParseSources(
            IServiceProvider serviceProvider,
            DirectoryInfo baseDirectory,
            string glob)
        {
            using var scope = serviceProvider.CreateScope();

            var fileParser = scope.ServiceProvider.GetRequiredService<GlobParser>();

            var result = await fileParser.ParseDirectoryGlob(baseDirectory, glob);

            if (result.HasErrors)
            {
                throw new NotImplementedException();
            }

            return Result.FromValue(result.Contents);
        }

        private static Result<IReadOnlyList<ContentUnit>> BuildContentUnits(
            IServiceProvider serviceProvider,
            IReadOnlyList<AstContentUnit> astContentUnits)
        {
            using var scope = serviceProvider.CreateScope();

            var builder = scope.ServiceProvider.GetRequiredService<ContentUnitsBuilder>();

            var result = builder.BuildContentUnits(astContentUnits);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.FromValue(result.Value);
        }

        private static Result<ContentUnitsTypeIndex> IndexContentUnits(
            IServiceProvider serviceProvider,
            IReadOnlyList<ContentUnit> contentUnits)

        {
            using var scope = serviceProvider.CreateScope();

            var typeIndexer = scope.ServiceProvider.GetRequiredService<PackageTypeIndexer>();

            var result = typeIndexer.IndexContentUnits(contentUnits);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private static Result<IReadOnlyList<CompiledContentUnit>> CompileContentUnits(
            IServiceProvider serviceProvider,
            IReadOnlyList<ContentUnit> contentUnits,
            ContentUnitsTypeIndex contentUnitsTypeIndex)
        {
            using var scope = serviceProvider.CreateScope();

            var compiler = scope.ServiceProvider.GetRequiredService<ContentUnitCompiler>();

            var compileResult = compiler.CompileContentUnits(contentUnits, contentUnitsTypeIndex);

            if (compileResult.IsError)
            {
                throw new NotImplementedException();
            }

            return compileResult;
        }

        private static Result<Package> PackageContentUnits(
            IServiceProvider serviceProvider,
            IReadOnlyList<CompiledContentUnit> contentUnits,
            ContentUnitsTypeIndex contentUnitsTypeIndex)
        {
            using var scope = serviceProvider.CreateScope();

            var packager = scope.ServiceProvider.GetRequiredService<ContentUnitsPackager>();

            var packageResult = packager.PackageContentUnits(contentUnits, contentUnitsTypeIndex);

            if (packageResult.IsError)
            {
                throw new NotImplementedException();
            }

            return packageResult;
        }

        private static Result<IWriterHandler> PrepareOutput(IServiceProvider serviceProvider, FileInfo? outputFile)
        {
            using var scope = serviceProvider.CreateScope();

            var writerProvider = scope.ServiceProvider.GetRequiredService<WriterProvider>();

            var result = writerProvider.PrepareOutput(outputFile);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private static async Task<Result> WritePackageContent(
            IServiceProvider serviceProvider,
            Package package,
            IWriterHandler writerHandler)
        {
            using var scope = serviceProvider.CreateScope();

            var packageWriter = scope.ServiceProvider.GetRequiredService<PackageWriter>();

            var writeResult = await packageWriter.WritePackage(package, writerHandler);

            if (writeResult.IsError)
            {
                throw new NotImplementedException();
            }

            return writeResult;
        }

        private static async Task<Result> WriteOutput(IServiceProvider serviceProvider, IWriterHandler writerHandler)
        {
            var result = await writerHandler.WriteOutputAsync();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return result;
        }
    }
}
