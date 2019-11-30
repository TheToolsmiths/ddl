using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Parser.Extensions;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Scopes.WithoutConditionals
{
    [TestClass]
    public class FileScopes
    {
        private const string FolderName = "scopes/withoutConditionals/";

        private static readonly string[] FileScopeFiles = {
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
            foreach (var fileScopeFile in FileScopeFiles)
            {
                var parser = FileParserUtils.CreateParserFromPath(fileScopeFile);

                var visitor = new FileContentsVisitor();

                var context = parser.fileContents();

                var fileContents = visitor.VisitFileContents(context);

                AssertFileContents(fileContents);
            }
        }

        private void AssertFileContents(FileContents fileContents)
        {
            Assert.IsNotNull(fileContents);

            // Assert no Struct Definitions on File Content Root
            {
                Assert.IsNotNull(fileContents.StructDefinitions);

                Assert.AreEqual(0, fileContents.StructDefinitions.Count);
            }

            // Assert any number of File Scopes
            {
                Assert.IsNotNull(fileContents.FileScopes);

                Assert.IsTrue(fileContents.FileScopes.Count > 0);

                foreach (var fileScope in fileContents.FileScopes)
                {
                    Assert.IsNotNull(fileScope);

                    AssertFileScope(fileScope);
                }
            }
        }

        private void AssertFileScope(FileScope fileScope)
        {
            Assert.IsNotNull(fileScope);

            // Assert Conditional Expression is empty
            {
                Assert.IsNotNull(fileScope.ConditionalExpression);

                Assert.IsTrue(fileScope.ConditionalExpression.IsEmpty);
            }

            AssertFileScopeContent(fileScope.Contents);
        }

        private void AssertFileScopeContent(FileContents content)
        {
            Assert.IsNotNull(content);

            // Assert any number of Struct Definitions
            {
                Assert.IsNotNull(content.StructDefinitions);

                Assert.IsTrue(content.StructDefinitions.Count >= 0);

                foreach (var structDefinition in content.StructDefinitions)
                {
                    AssertStructDefinition(structDefinition);
                }
            }

            // Assert any number of File Scopes
            {
                Assert.IsNotNull(content.FileScopes);

                Assert.IsTrue(content.FileScopes.Count >= 0);

                foreach (var fileScope in content.FileScopes)
                {
                    AssertFileScope(fileScope);
                }
            }
        }

        private void AssertStructDefinition(StructDefinition structDefinition)
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
                Assert.IsNotNull(structDefinition.Content.GetAllFields());

                Assert.IsTrue(structDefinition.Content.GetAllFields().Count() >= 0);
            }

            // Assert no of Struct Scopes
            {
                Assert.AreEqual(0, structDefinition.Content.GetAllScopes().Count());
            }
        }
    }
}
