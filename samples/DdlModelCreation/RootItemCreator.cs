using System;
using TheToolsmiths.Ddl.Models.Build.Enums.Builders;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Usage.Builders;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;

namespace DdlModelCreation
{
    public static class RootItemCreator
    {
        public static void CreateRootScopeItems(ScopeContentBuilder builder)
        {
            builder.Items.Add(CreateStructWithFieldTestTypes());
            builder.Items.Add(CreateStructWithScopes());
            builder.Items.Add(CreateGenericStructWithSimpleTypeParameter());
            builder.Items.Add(CreateGenericStructWithMultipleTypeParameter());
            builder.Items.Add(CreateEnumStructConstantValue());
            builder.Items.Add(CreateEnumTextureType());
        }

        private static IRootItem CreateEnumTextureType()
        {
            //def enum struct ConstantValue
            //{
            var enumStructBuilder = new EnumDefinitionBuilder()
            .WithSimpleTypeName("TextureType");

            //Unit,
            enumStructBuilder.WithConstant("Unit");

            //Texture2D,
            enumStructBuilder.WithConstant("Texture2D");

            //Texture3D,
            enumStructBuilder.WithConstant("Texture3D");

            //TextureCube,
            enumStructBuilder.WithConstant("TextureCube");

            // }

            return enumStructBuilder.Build();
        }

        private static IRootItem CreateEnumStructConstantValue()
        {
            //def enum struct ConstantValue
            //{
            var enumStructBuilder = new EnumStructDefinitionBuilder()
            .WithSimpleTypeName("ConstantValue");

            {
                //Unit,
                enumStructBuilder.WithVariant("Unit");
            }

            {
                // Bool {
                var contentBuilder = enumStructBuilder.WithVariant("Bool").Content;

                //     value: scalar::bool,
                contentBuilder.AddField("value").WithType().StartsWithSimplePath("scalar", "bool");

                // }
            }

            {
                //Int {
                var contentBuilder = enumStructBuilder.WithVariant("Int").Content;

                //     value: u32,
                contentBuilder.AddField("value").WithType().StartsWithSimplePath("u32");

                // }
            }

            {
                //Float {
                var contentBuilder = enumStructBuilder.WithVariant("Float").Content;

                //     value: f32,
                contentBuilder.AddField("value").WithType().StartsWithSimplePath("f32");

                // }
            }

            {
                //Vector2 {
                var contentBuilder = enumStructBuilder.WithVariant("Vector2").Content;

                //     value: vec2::f32,
                contentBuilder.AddField("value").WithType().StartsWithSimplePath("vec2", "f32");

                // }
            }

            {
                //Vector3 {
                var contentBuilder = enumStructBuilder.WithVariant("Vector3").Content;

                //     value: vec3::f32,
                contentBuilder.AddField("value").WithType().StartsWithSimplePath("vec3", "f32");

                // }
            }

            {
                //Vector4 {
                var contentBuilder = enumStructBuilder.WithVariant("Vector4").Content;

                //     value: vec4::f32,
                contentBuilder.AddField("value").WithType().StartsWithSimplePath("vec4", "f32");

                // }
            }

            // }

            return enumStructBuilder.Build();
        }

        private static IRootItem CreateGenericStructWithMultipleTypeParameter()
        {
            //def struct GenericStructWithMultipleTypeParameter<TString, TFoo, TBar>
            //{
            var itemNameIdentifier = GenericTypeNameIdentifier.Create("GenericStructWithSimpleTypeParameter", "TString", "TFoo", "TBar");
            var typeName = new ItemTypeName(itemNameIdentifier);

            var contentBuilder = new StructContentBuilder();

            var structContent = contentBuilder.Build();
            
            throw new NotImplementedException();
            //var structDefinition = new StructDefinition(typeName, structContent);
            ////}

            //return structDefinition;
        }

        private static IRootItem CreateGenericStructWithSimpleTypeParameter()
        {
            const string genericParam = "TString";

            //def struct GenericStructWithSimpleTypeParameter<TString>
            //{
            var itemNameIdentifier = GenericTypeNameIdentifier.Create("GenericStructWithSimpleTypeParameter", genericParam);
            var typeName = new ItemTypeName(itemNameIdentifier);

            var contentBuilder = new StructContentBuilder();

            contentBuilder.AddField("field1").WithType().StartsWithSimplePath(genericParam);

            var structContent = contentBuilder.Build();

            throw new NotImplementedException();
            //var structDefinition = new StructDefinition(typeName, structContent);
            ////}

            //return structDefinition;
        }

        private static IRootItem CreateStructWithScopes()
        {
            //[TestAttributeType { value1: false, value2: 0b10 }]
            //def struct StructWithScopes
            //{
            var itemNameIdentifier = new SimpleTypeNameIdentifier("StructWithScopes");
            var typeName = new ItemTypeName(itemNameIdentifier);

            var contentBuilder = new StructContentBuilder();
            //    // Scope
            //    scope
            contentBuilder.AddScope()
                //    {        
                //        field1: TestGenericType<Foo>
                .AddField("field1")
                .WithType()
                .StartsWithGenericPath("TestGenericType", "Foo");
            //    }

            //    // Scope With Conditional Expression
            //    scope(DEFINE_1 != "Something" || (false && true) || false || DEFINE_2 || !DEFINE_3)
            ConditionalExpression condition = ConditionalExpression.CreateOr(
                // DEFINE_1 != "Something"
                DefineCompareExpression.CreateNotEquals("DEFINE_1", "Something"),

                // (false && true)
                LogicalExpression.CreateAnd(BoolLiteralExpression.False, BoolLiteralExpression.True),

                // false
                BoolLiteralExpression.False,

                // DEFINE_2
                DefineCheckExpression.CreateDefined("DEFINE_2"),

                // !DEFINE_3
                DefineCheckExpression.CreateNotDefined("DEFINE_3"));

            var scopeBuilder = contentBuilder.AddConditionalScope(condition);
            //    {        
            {
                //        [TestAttributeType { struct1: {value1: false, value2: 10 } }]
                //        field1: ref test::Map<string<foo>, test::Bar>,
                var fieldBuilder = scopeBuilder.AddField("field1");

                fieldBuilder.AddTypedAttribute("TestAttributeType")
                    .WithStructuredInitialization()
                    .WithStructuredField("struct1")
                    .WithField("value1", false)
                    .WithField("value2", 10);

                var genericPart = fieldBuilder.WithType()
                    .SetRefReference()
                    .StartsWithSimplePath("test")
                    .AddGenericPart("Map");

                genericPart.AddGenericParameter().StartsWithGenericPath("string", "foo");

                genericPart.AddGenericParameter().StartsWithSimplePath("test", "Bar");
            }

            {
                //        [IgnoreWhen(DEFINE_1 || (false || true))]
                //        field2: bool,
                var fieldBuilder = scopeBuilder.AddField("field2");

                fieldBuilder.WithType().StartsWithSimplePath("bool");

                ConditionalExpression expression = ConditionalExpression.CreateOr(
                    DefineCheckExpression.CreateDefined("DEFINE_1"),
                    LogicalExpression.CreateOr(BoolLiteralExpression.False, BoolLiteralExpression.True));
                fieldBuilder.AddConditionalAttribute("IgnoreWhen", expression);
            }

            {
                //        field3: i32,

                var fieldBuilder = scopeBuilder.AddField("field3");

                fieldBuilder.WithType().StartsWithSimplePath("i32");
            }

            //    }   

            var structContent = contentBuilder.Build();

            throw new NotImplementedException();
            //var structDefinition = new StructDefinition(typeName, structContent);
            ////}

            //return structDefinition;
        }

        private static IRootItem CreateStructWithFieldTestTypes()
        {
            //def struct StructWithFieldTestTypes
            //{
            var itemNameIdentifier = new SimpleTypeNameIdentifier("StructWithFieldTestTypes");
            var typeName = new ItemTypeName(itemNameIdentifier);

            var contentBuilder = new StructContentBuilder();

            //    field1: alias1,
            contentBuilder.AddField("field1").WithType().StartsWithSimplePath("alias1");

            //    field2: ::alias1,
            contentBuilder.AddField("field2").WithType().StartsRootedWithSimplePath("alias1");

            //    field3: foo::foo_type<int>,
            contentBuilder.AddField("field3").WithType().StartsWithSimplePath("foo").AddGenericPart("foo_type", "int");

            //    field4: ::GenericStructWithSimpleTypeParameter<string>,
            contentBuilder.AddField("field4")
                .WithType()
                .StartsRootedWithGenericPath("GenericStructWithSimpleTypeParameter", "string");

            //    field5: const ref std::experimental::TestFieldType<Result<int[], ::std::Error<string>>, std::Foo[]>[][20][20, 45, 0b101],
            {
                TypeReferenceBuilder field5Type = contentBuilder.AddField("field5")
                    .WithType()
                    .MakeArraySized(
                        ArrayTypeStorageBuilder.WithDynamicSize().AddFixedSize(20).AddFixedSizes(20, 45, 10))
                    .SetRefReference()
                    .MakeConst()
                    .StartsWithSimplePath("std", "experimental");

                var genericPartBuilder = field5Type.AddGenericPart("TestFieldType");

                // Result<int[], ::std::Error<string>>
                {
                    var resultGenericBuilder = genericPartBuilder.AddGenericParameter().StartsWithGenericPart("Result");

                    // int[]
                    resultGenericBuilder.AddGenericParameter().StartsWithSimplePath("int").MakeArrayDynamicSized();

                    // ::std::Error<string>
                    resultGenericBuilder.AddGenericParameter()
                        .StartsRootedWithSimplePath("std")
                        .AddGenericPart("Error", "string");
                }

                // std::Foo[]
                {
                    genericPartBuilder.AddGenericParameter().StartsWithSimplePath("std", "Foo").MakeArrayDynamicSized();
                }
            }

            // field6: ref std::experimental::TestFieldType<Foo>[][20][20, 45, 0x02]
            contentBuilder.AddField("field6")
                .WithType()
                .SetRefReference()
                .MakeArraySized(
                    ArrayTypeStorageBuilder.WithDynamicSize().AddFixedSize(20).AddFixedSizes(20, 45, 2))
                .StartsWithSimplePath("std", "experimental")
                .AddGenericPart("TestFieldType", "Foo");

            var structContent = contentBuilder.Build();

            throw new NotImplementedException();
            //var structDefinition = new StructDefinition(typeName, structContent);
            ////}

            //return structDefinition;
        }
    }
}
