using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
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

            this.AssertStructDefinition(structDefinition);
        }

        [TestMethod]
        public void TestFileContentsStructDefinition()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionFile);

            var visitor = new FileContentVisitor();

            var fileContentsContext = parser.fileContents();

            var fileContents = visitor.VisitFileContents(fileContentsContext);

            Assert.IsNotNull(fileContents);

            Assert.IsNotNull(fileContents.Items);

            Assert.AreEqual(1, fileContents.Items.GetAllStructDefinitions().Count());

            var structDefinition = fileContents.Items.GetAllStructDefinitions().First();

            this.AssertStructDefinition(structDefinition);
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

            // Assert content is valid
            {
                Assert.IsNotNull(structDefinition.Content);

                Assert.IsNotNull(structDefinition.Content.Items);
            }

            // Assert Empty Fields
            {
                Assert.AreEqual(0, structDefinition.Content.GetAllFields().Count());
            }

            // Assert Empty Scopes
            {
                Assert.IsFalse(structDefinition.Content.HasAnyScopes());
            }
        }
    }
}
