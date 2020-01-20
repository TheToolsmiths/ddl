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

                Assert.AreEqual(0, fileContent.GetAllStructDefinitions().Count());
            }

            // Assert any number of File Scopes
            {
                Assert.IsTrue(fileContent.GetAllScopes().Any());

                foreach (var fileScope in fileContent.GetAllScopes())
                {
                    Assert.IsNotNull(fileScope);

                    AssertFileScope(fileScope);
                }
            }
        }

        private static void AssertFileScope(FileScope fileScope)
        {
            Assert.IsNotNull(fileScope);

            // Assert Conditional Expression is valid
            {
                Assert.IsNotNull(fileScope.ConditionalExpression);

                Assert.IsFalse(fileScope.ConditionalExpression.IsEmpty);

                ConditionalExpressionsUtils.AssertNotEmptyConditionalExpression(fileScope.ConditionalExpression);
            }

            AssertFileScopeContent(fileScope.Content);
        }

        private static void AssertFileScopeContent(FileContent content)
        {
            Assert.IsNotNull(content);

            // Assert any number of Struct Definitions
            {
                Assert.IsNotNull(content.Items);

                Assert.IsTrue(content.GetAllStructDefinitions().Count() >= 0);

                foreach (var structDefinition in content.GetAllStructDefinitions())
                {
                    AssertStructDefinition(structDefinition);
                }
            }

            // Assert any number of File Scopes
            {
                Assert.IsTrue(content.GetAllScopes().Count() >= 0);

                foreach (var fileScope in content.GetAllScopes())
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
