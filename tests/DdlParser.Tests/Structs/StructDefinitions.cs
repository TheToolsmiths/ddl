using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Structs
{
    [TestClass]
    public class StructDefinitions
    {
        private const string StructDefinitionFile = "structs/structDefinition.ddl";

        [TestMethod]
        public void TestStructDefinition()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionFile);

            var visitor = new StructDefinitionVisitor();

            var defStruct = parser.defStruct();

            var structDefinition = visitor.VisitDefStruct(defStruct);

            AssertStructDefinition(structDefinition);
        }

        [TestMethod]
        public void TestFileContentsStructDefinition()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionFile);

            var visitor = new FileContentsVisitor();

            var fileContentsContext = parser.fileContents();

            var fileContents = visitor.VisitFileContents(fileContentsContext);

            Assert.IsNotNull(fileContents);

            Assert.IsNotNull(fileContents.StructDefinitions);

            Assert.AreEqual(1, fileContents.StructDefinitions.Count);

            var structDefinition = fileContents.StructDefinitions.First();

            AssertStructDefinition(structDefinition);
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

            // Assert Empty Fields
            {
                Assert.IsNotNull(structDefinition.Content.Fields);

                Assert.AreEqual(0, structDefinition.Content.Fields.Count);
            }

            // Assert Empty Scopes
            {
                Assert.IsNotNull(structDefinition.Content.Scopes);

                Assert.AreEqual(0, structDefinition.Content.Scopes.Count);
            }
        }
    }
}
