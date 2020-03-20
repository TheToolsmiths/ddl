using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Scopes.WithConditionals
{
    [TestClass]
    public class FileScopes
    {
        private const string FolderName = @"scopes\withConditionals\";

        private static readonly string[] fileScopeFiles = {
            NestedScopeFile,
            NestedScopeWithStructFile,
            SingleScopeFile,
            SingleScopeWithStructFile
        };

        private const string NestedScopeFile = FolderName + "nestedFileScopes.ddl";
        private const string NestedScopeWithStructFile = FolderName + "nestedFileScopeWithStructDefinition.ddl";
        private const string SingleScopeFile = FolderName + "singleFileScope.ddl";
        private const string SingleScopeWithStructFile = FolderName + "singleFileScopeWithStructDefinition.ddl";

        [TestMethod]
        public void TestAllFileScopes()
        {
            foreach (string fileScopeFile in fileScopeFiles)
            {
                var parser = FileParserUtils.CreateParserFromPath(fileScopeFile);

                var visitor = new FileContentVisitor();

                var context = parser.fileContents();

                var fileContents = visitor.VisitFileContents(context);

                this.AssertFileContents(fileContents);
            }
        }

        private void AssertFileContents(FileContent fileContent)
        {
            Assert.IsNotNull(fileContent);

            // Assert no Struct Definitions on File Content Root
            {
                Assert.IsNotNull(fileContent.Items);

                Assert.AreEqual(0, fileContent.Items.GetAllStructDefinitions().Count());
            }

            // Assert any number of File Scopes
            {
                Assert.IsTrue(fileContent.Items.GetAllScopes().Any());

                foreach (var fileScope in fileContent.Items.GetAllScopes())
                {
                    Assert.IsNotNull(fileScope);

                    AssertFileScope(fileScope);
                }
            }
        }

        private static void AssertFileScope(RootScope rootScope)
        {
            Assert.IsNotNull(rootScope);

            // Assert Conditional Expression is valid
            {
                Assert.IsNotNull(rootScope.ConditionalExpression);

                Assert.IsFalse(rootScope.ConditionalExpression.IsEmpty);

                ConditionalExpressionsUtils.AssertNotEmptyConditionalExpression(rootScope.ConditionalExpression);
            }

            AssertFileScopeContent(rootScope.ContentItems);
        }

        private static void AssertFileScopeContent(IReadOnlyList<IRootContentItem> contentItems)
        {
            Assert.IsNotNull(contentItems);

            // Assert any number of Struct Definitions
            {
                Assert.IsNotNull(contentItems);

                Assert.IsTrue(contentItems.GetAllStructDefinitions().Count() >= 0);

                foreach (var structDefinition in contentItems.GetAllStructDefinitions())
                {
                    AssertStructDefinition(structDefinition);
                }
            }

            // Assert any number of File Scopes
            {
                Assert.IsTrue(contentItems.GetAllScopes().Count() >= 0);

                foreach (var fileScope in contentItems.GetAllScopes())
                {
                    AssertFileScope(fileScope);
                }
            }
        }

        private static void AssertStructDefinition(StructDefinition structDefinition)
        {
            // Assert TypeName
            {
                Assert.IsNotNull(structDefinition.TypeName.Name);

                Assert.AreEqual(Identifier.FromString("TestStructType"), structDefinition.TypeName.Name);
            }

            // Assert Empty Attributes
            {
                Assert.IsNotNull(structDefinition.Attributes);

                Assert.AreEqual(0, structDefinition.Attributes.Count);
            }

            // Assert content is valid
            {
                Assert.IsNotNull(structDefinition.Content);

                Assert.IsNotNull(structDefinition.Content.Items);
            }

            // Assert any number of Fields
            {
                Assert.IsTrue(structDefinition.Content.GetAllFields().Count() >= 0);
            }

            // Assert no of Struct Scopes
            {
                Assert.IsFalse(structDefinition.Content.HasAnyScopes());
            }
        }
    }
}
