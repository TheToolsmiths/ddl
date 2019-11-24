﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Tests.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser.Tests.Scopes.WithoutConditionals
{
    [TestClass]
    public class StructScopes
    {
        private const string FolderName = "scopes/withoutConditionals/";

        private static readonly string[] FileScopeFiles = {
            StructWithFieldsAndSingleScopeFile,
            StructWithNestedScopeFile,
            StructWithSingleScopeFile,
            StructWithSingleScopeWithFieldFile,
            StructWithSingleScopeWithFieldsFile
        };

        private const string StructWithFieldsAndSingleScopeFile = FolderName + "structDefinitionWithFieldsAndSingleScope.ddl";
        private const string StructWithNestedScopeFile = FolderName + "structDefinitionWithNestedScope.ddl";
        private const string StructWithSingleScopeFile = FolderName + "structDefinitionWithSingleScope.ddl";
        private const string StructWithSingleScopeWithFieldFile = FolderName + "structDefinitionWithSingleScopeWithField.ddl";
        private const string StructWithSingleScopeWithFieldsFile = FolderName + "structDefinitionWithSingleScopeWithFields.ddl";

        [TestMethod]
        public void TestAllStructScopes()
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

            // Assert any number of Struct Definitions on File Content Root
            {
                Assert.IsNotNull(fileContents.StructDefinitions);

                Assert.IsTrue(fileContents.StructDefinitions.Count > 0);

                foreach (var structDefinition in fileContents.StructDefinitions)
                {
                    Assert.IsNotNull(structDefinition);

                    AssertStructDefinition(structDefinition);
                }
            }

            // Assert no of File Scopes
            {
                Assert.IsNotNull(fileContents.FileScopes);

                Assert.AreEqual(0, fileContents.FileScopes.Count);
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

            // Assert any number of Fields
            {
                Assert.IsNotNull(structDefinition.Content.Fields);

                Assert.IsTrue(structDefinition.Content.Fields.Count >= 0);
            }

            // Assert any number of Scopes
            {
                Assert.IsNotNull(structDefinition.Content.Scopes);

                Assert.IsTrue(structDefinition.Content.Scopes.Count >= 0);

                foreach (var contentScope in structDefinition.Content.Scopes)
                {
                    AssertStructScope(contentScope);
                }
            }
        }

        private void AssertStructScope(StructScope structScope)
        {
            Assert.IsNotNull(structScope);

            Assert.IsNotNull(structScope.StructContent);

            var content = structScope.StructContent;

            // Assert any number of Field Definitions
            {
                Assert.IsNotNull(content.Fields);

                Assert.IsTrue(content.Fields.Count >= 0);
            }

            // Assert any number of Struct Scopes
            {
                Assert.IsNotNull(content.Scopes);

                Assert.IsTrue(content.Scopes.Count >= 0);

                foreach (var fileScope in content.Scopes)
                {
                    AssertStructScope(fileScope);
                }
            }
        }
    }
}
