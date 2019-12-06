using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
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
            foreach (string fileScopeFile in FileScopeFiles)
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
                Assert.IsNotNull(fileContent.Items);

                Assert.IsTrue(fileContent.GetAllScopes().Any());

                foreach (var fileScope in fileContent.GetAllScopes())
                {
                    Assert.IsNotNull(fileScope);

                    this.AssertFileScope(fileScope);
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

            this.AssertFileScopeContent(fileScope.Content);
        }

        private void AssertFileScopeContent(FileContent content)
        {
            Assert.IsNotNull(content);

            // Assert any number of Struct Definitions
            {
                Assert.IsNotNull(content.Items);

                Assert.IsTrue(content.GetAllStructDefinitions().Count() >= 0);

                foreach (var structDefinition in content.GetAllStructDefinitions())
                {
                    this.AssertStructDefinition(structDefinition);
                }
            }

            // Assert any number of File Scopes
            {
                Assert.IsNotNull(content.Items);

                Assert.IsTrue(content.GetAllScopes().Count() >= 0);

                foreach (var fileScope in content.GetAllScopes())
                {
                    this.AssertFileScope(fileScope);
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
