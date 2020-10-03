﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Packagers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.TypeIndexers;
using TheToolsmiths.Ddl.Cli.TypeResolvers;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Index;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Models.Types.Index;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

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
            var buildResult = await BuildContentUnits(serviceProvider, astContentUnits);

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
            var typeResolveResult = ResolveContentUnitsTypes(serviceProvider, contentUnits, packageIndex);

            if (typeResolveResult.IsError)
            {
                throw new NotImplementedException();
            }

            var resolvedContentUnits = typeResolveResult.Value;

            timer.Stop();

            // Resolve all model's content units types
            var packageResult = PackageContentUnits(serviceProvider, resolvedContentUnits, packageIndex);

            if (packageResult.IsError)
            {
                throw new NotImplementedException();
            }

            var package = packageResult.Value;

            throw new NotImplementedException();
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

        private static async Task<Result<IReadOnlyList<ContentUnit>>> BuildContentUnits(
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

        private static Result<PackageTypeIndex> IndexContentUnits(
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

        private static Result<IReadOnlyList<ContentUnit>> ResolveContentUnitsTypes(
            IServiceProvider serviceProvider,
            IReadOnlyList<ContentUnit> contentUnits,
            PackageTypeIndex packageTypeIndex)
        {
            using var scope = serviceProvider.CreateScope();

            var typeResolver = scope.ServiceProvider.GetRequiredService<ContentUnitsTypeResolver>();

            var typeResolveResult = typeResolver.ResolveContentUnitsTypes(contentUnits, packageTypeIndex);

            if (typeResolveResult.IsError)
            {
                throw new NotImplementedException();
            }

            return typeResolveResult;
        }

        private static Result<object> PackageContentUnits(
            IServiceProvider serviceProvider,
            IReadOnlyList<ContentUnit> contentUnits,
            PackageTypeIndex packageTypeIndex)
        {
            using var scope = serviceProvider.CreateScope();

            var typeResolver = scope.ServiceProvider.GetRequiredService<ContentUnitsPackager>();

            var typeResolveResult = typeResolver.PackageContentUnits(contentUnits, packageTypeIndex);

            if (typeResolveResult.IsError)
            {
                throw new NotImplementedException();
            }

            return typeResolveResult;
        }
    }
}
