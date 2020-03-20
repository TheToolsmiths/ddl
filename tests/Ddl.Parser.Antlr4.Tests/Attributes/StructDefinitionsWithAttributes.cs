using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Attributes
{
    [TestClass]
    public class StructDefinitionsWithAttributes
    {
        private const string StructDefinitionWithAttributeFile = "attributes/structDefinitionWithAttribute.ddl";
        private const string StructDefinitionWithAttributesFile = "attributes/structDefinitionWithAttributes.ddl";

        [TestMethod]
        public void TestFileContentsStructDefinitionWithAttribute()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionWithAttributeFile);

            var visitor = new FileContentVisitor();

            var fileContentsContext = parser.fileContents();

            var fileContents = visitor.VisitFileContents(fileContentsContext);

            Assert.IsNotNull(fileContents);

            Assert.IsNotNull(fileContents.Items);

            Assert.AreEqual(1, fileContents.Items.GetAllStructDefinitions().Count());

            var structDefinition = fileContents.Items.GetAllStructDefinitions().First();

            this.AssertStructDefinition(structDefinition);
        }

        [TestMethod]
        public void TestFileContentsStructDefinitionWithAttributes()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructDefinitionWithAttributesFile);

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

            // Assert Attributes
            {
                Assert.IsNotNull(structDefinition.Attributes);

                Assert.IsTrue(structDefinition.Attributes.Count > 0);
            }

            // Assert Empty Content
            {
                Assert.IsNotNull(structDefinition.Content);

                Assert.IsTrue(structDefinition.Content.IsEmpty);
            }
        }
    }
}
