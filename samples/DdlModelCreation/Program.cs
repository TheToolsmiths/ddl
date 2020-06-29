using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Writer;
using TheToolsmiths.Ddl.Writer.OutputWriters;

namespace DdlModelCreation
{
    public static class Program
    {
        public static void Main()
        {
            var pipe = new Pipe();

            Task.WaitAll(
                Task.Run(() => WriteModel(pipe.Writer)),
                Task.Run(() => WriteOutput(pipe.Reader)));

            Console.WriteLine("Model created");
        }

        private static async Task WriteModel(PipeWriter pipeWriter)
        {
            var scopeContent = CreateFileScopeContent();

            var rootScope = new RootScope(scopeContent);

            var contentUnit = new ContentUnit(rootScope);

            await DdlWriter.Write(contentUnit, pipeWriter).ConfigureAwait(false);

            await pipeWriter.CompleteAsync().ConfigureAwait(false);
        }

        private static async Task WriteOutput(PipeReader pipeReader)
        {
            var result = await OutputWriter.WriteToStdOut(pipeReader).ConfigureAwait(false);

            if (result.IsError)
            {
                Console.WriteLine($"Error writing to console: {result.ErrorMessage}");
            }

            await pipeReader.CompleteAsync().ConfigureAwait(false);
        }

        private static ScopeContent CreateFileScopeContent()
        {
            var importPaths = CreateRootImports();

            var items = RootItemCreator.CreateRootScopeItems();

            var scopes = CreateRootScopes();

            return ScopeContent.Create(items, scopes, importPaths);
        }

        private static IReadOnlyList<ImportStatement> CreateRootImports()
        {
            var imports = new List<ImportStatement>
            {
                //import module_name1::export1;
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name1", "export1")),

                //import::module_name2::export1;
                ImportStatement.Create(ImportPath.CreateRooted("module_name2", "export1")),

                //import module_name3 as name1;
                ImportStatement.CreateWithAlias(ImportPath.CreateNonRooted("module_name3"), "name1"),

                //import module_name4::export1 as name3;
                ImportStatement.CreateWithAlias(ImportPath.CreateNonRooted("module_name4", "export1"), "name3"),

                //import module_name5::{ export1 };
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name5", "export1")),

                //import module_name6;
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name6")),

                //import { module_name7 };
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name7")),

                //import module_name8::{ export1 as alias1 };
                ImportStatement.CreateWithAlias(ImportPath.CreateNonRooted("module_name8", "export1"), "alias1"),

                //import module_name9::{ export1, export2 };
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name9", "export1")),
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name9", "export2")),

                //import module_name10::path::to::specific::unexported::file::{ foo , bar };
                ImportStatement.Create(
                    ImportPath.CreateNonRooted("module_name10", "path", "to", "specific", "unexported", "file", "foo")),
                ImportStatement.Create(
                    ImportPath.CreateNonRooted("module_name10", "path", "to", "specific", "unexported", "file", "bar")),

                //import ::module_name11::{ export1 , export2 as alias2 };
                ImportStatement.Create(ImportPath.CreateRooted("module_name11", "export1")),
                ImportStatement.CreateWithAlias(ImportPath.CreateNonRooted("module_name11", "export2"), "alias2"),

                //import module_name12::{ sub1 };
                ImportStatement.Create(ImportPath.CreateNonRooted("module_name12", "sub1")),

                //import module_name13::{ sub1 as name5 };
                ImportStatement.CreateWithAlias(ImportPath.CreateNonRooted("module_name13", "sub1"), "name5")
            };

            return imports;
        }

        private static IReadOnlyList<IRootScope> CreateRootScopes()
        {
            List<IRootScope> scopes = new List<IRootScope>();

            // Empty Scope With Conditional Expression
            {
                ////scope((DEFINE_1 && ((DEFINE_2 != "Something") && DEFINE_3 == "Something else")) || false)
                ////{
                ////}

                var conditionalExpression = ConditionalExpression.CreateOr(
                    LogicalExpression.CreateAnd(
                        DefineCheckExpression.CreateDefined("DEFINE_1"),
                        DefineCompareExpression.CreateNotEquals("DEFINE_2", "Something"),
                        DefineCompareExpression.CreateEquals("DEFINE_3", "Something else")
                        ),
                    BoolLiteralExpression.False);

                var scope = new ConditionalRootScope(conditionalExpression, ScopeContent.Empty);
                scopes.Add(scope);
            }

            return scopes;
        }
    }
}
