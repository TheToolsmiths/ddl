using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Structs
{
    [TestClass]
    public class StructDefinitionsWithFields
    {
        private const string StructDefinitionWithFieldFile = "structs/structDefinitionWithField.ddl";
        private const string StructDefinitionWithFieldsFile = "structs/structDefinitionWithFields.ddl";

        [TestMethod]
        public void TestFileContentsStructDefinitionWithField()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionWithFieldFile);

            var visitor = new FileContentsVisitor();

            var fileContentsContext = parser.fileContents();

            var fileContents = visitor.VisitFileContents(fileContentsContext);

            AssertFileContents(fileContents);
        }

        [TestMethod]
        public void TestFileContentsStructDefinitionWithFields()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionWithFieldsFile);

            var visitor = new FileContentsVisitor();

            var fileContentsContext = parser.fileContents();

            var fileContents = visitor.VisitFileContents(fileContentsContext);

            AssertFileContents(fileContents);
        }

        private void AssertFileContents(FileContents fileContents)
        {
            Assert.IsNotNull(fileContents);

            Assert.IsNotNull(fileContents.StructDefinitions);

            Assert.AreEqual(2, fileContents.StructDefinitions.Count);

            foreach (var structDefinition in fileContents.StructDefinitions)
            {
                AssertStructDefinition(structDefinition);
            }
        }

        private void AssertStructDefinition(StructDefinition structDefinition)
        {
            Assert.IsNotNull(structDefinition);

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

            // Assert Valid Fields
            {
                Assert.IsNotNull(structDefinition.Content.Fields);

                Assert.IsTrue(structDefinition.Content.Fields.Count > 0);
            }

            // Assert Valid Fields
            {
                Assert.IsNotNull(structDefinition.Content.Scopes);

                Assert.AreEqual(0, structDefinition.Content.Scopes.Count);
            }
        }
    }
}
