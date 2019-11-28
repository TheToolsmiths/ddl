using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Parser.Extensions;
using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Attributes
{
    [TestClass]
    public class StructFieldWithAttributes
    {
        private const string StructFieldWithAttributeFile = "attributes/structFieldWithAttribute.ddl";
        private const string StructFieldWithAttributesFile = "attributes/structFieldWithAttributes.ddl";

        [TestMethod]
        public void TestFileContentsStructFieldWithAttribute()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructFieldWithAttributeFile);

            var visitor = new FileContentsVisitor();

            var fileContentsContext = parser.fileContents();

            var fileContents = visitor.VisitFileContents(fileContentsContext);

            Assert.IsNotNull(fileContents);

            Assert.IsNotNull(fileContents.StructDefinitions);

            Assert.AreEqual(1, fileContents.StructDefinitions.Count);

            var structDefinition = fileContents.StructDefinitions.First();

            AssertStructDefinition(structDefinition);
        }

        [TestMethod]
        public void TestFileContentsStructFieldWithAttributes()
        {
            var parser = FileParserUtils.CreateParserFromPath(StructFieldWithAttributesFile);

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

                Assert.AreEqual(structDefinition.Attributes.Count, 0);
            }

            // Assert content is valid
            {
                Assert.IsNotNull(structDefinition.Content);

                Assert.IsNotNull(structDefinition.Content.Items);

                Assert.IsFalse(structDefinition.Content.IsEmpty);
            }

            // Assert Single Field
            {
                Assert.IsTrue(structDefinition.Content.HasAnyFieldDefinitions());

                foreach (var structDefinitionField in structDefinition.Content.GetAllFields())
                {
                    Assert.IsTrue(structDefinitionField.Attributes.Count > 0);
                }
            }

            // Assert no other content inside Struct Definition
            {
                Assert.IsFalse(structDefinition.Content.HasAnyScopes());
            }
        }
    }
}
