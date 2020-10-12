// README: This file is meant to have all the grammar features and serve as a test case
/******/

;;;;;;

/***************
**  Imports   ** 
***************/
import module_name1::export1;
import ::module_name2::export2;
import module_name3 as name1;
import module_name4::export1 as name3;
import module_name5::{ export5 };
import module_name6;
import { module_name7 };
import module_name8::{ export1 as alias1 };
import module_name9::{ export9, export9_other };
import module_name10::path::to::specific::unexported::file::{ foo , bar };
import ::module_name11::{ export11 , export2 as alias12 };
import module_name12::{ sub1 };
import module_name13::{ sub1 as name5 };

;;


def struct StructWithFieldTestTypes
{
    field5: const ref std::experimental::TestFieldType<Result<int[], ::std::Error<string>>,std::Foo[]>[][20][20, 45, 0b101],
    field1: alias1,
    field2: ::alias1,
    field3: foo::foo_type<int>,
    field4: ::GenericStructWithSimpleTypeParameter<string>,
    field6: ref std::experimental::TestFieldType<Foo>[][20][20, 45, 0x02],
    // Errors
    // field1: ref std::experimental::<Foo>[][20][20, 45, 0x02],
    // field2: ::std::experimental::[][20][20, 45, 0x02],
}

;;

/***************
Sample Block Comment
***************/
[IgnoreWhen(DEFINE_1 || (false || true))]
[std::experimental::EnableWhen(DEFINE_2)]
[key = "TestValue"]
def struct EmptyStruct
{

};;;;

/*def 
struct Foo  EmptyStructOnMultipleLines*/

def 
struct /*Foo */
 EmptyStructOnMultipleLines
{
// Foo

}

def struct EmptyStructOnMultipleLines
{

}

[foo1 = "stuff",
 foo2 = Foo { name: "something" },
 foo2 = { name: "something" },
 foo3 = ::std::Foo { name: "something" },
 ::std::Foo { name: "something" },
 std::Foo { name: "something" },
 Foo { name: "something" },
 Foo]
def struct EmptyStructWithSingleBlockAttributeWithMultipleEntries
{
};;;;

def struct EmptyStructWithScopes
{
    // Empty Scope
    scope
    {        
    }

    // Empty Scope With Conditional Expression
    scope (false)
    {        
    }
}

// Scope with empty condition and def structs
scope ()
{   
    [key = TestAttributeType]
    def struct EmptyStruct
    {    
    }

    [TestAttributeType]
    def struct StructWithSingleField
    {    
        [TestAttributeType {}]
        field1: ref TestFieldType
    }
}

// Empty Scope
scope
{        
}

// Empty Scope With Conditional Expression
scope ((DEFINE_1 && ((DEFINE_2 != "Something") && DEFINE_3 == "Something else"))|| false)
{        
};;;;

[TestAttributeType { value1: false, value2: 0b10 }]
def struct StructWithScopes
{
    // Scope
    scope
    {        
        field1: TestGenericType<Foo>
    }

    // Scope With Conditional Expression
    scope ( DEFINE_1 != "Something" || (false && true) || false || DEFINE_2 || !DEFINE_3)
    {        
        [TestAttributeType { struct1: {value1: false, value2: 10 }}]
        field1: ref test::Map<string<foo>, test::Bar>,

        [IgnoreWhen(DEFINE_1 || (false || true))]
        field2: bool,

        field3: i32,
    }   
}

def struct StructWithFieldsAndScopes
{
    field1: handle TestFieldType,
    field2: bool,
    field3: i32,

    // Empty Scope
    scope
    {        
        field4: i32
    }

    // Empty Scope With Conditional Expression
    scope (!false)
    {        
        field5: std::experimental::TestFieldType,
        field6: bool,
    }

    field1: TestFieldType[][20][20, 45, 0x02],
}

def struct StructWithMultipleFields
{    
    [TestAttributeType { struct1: {value1: false, value2: 10 }}]
    field1: TestFieldType,
    field2: owns std::experimental::bool,
    field3: i32,
}

/*********************
    Scope Attributes
**********************/
[foo1 = "stuff"]
[foo2 = Foo { name: "something" }]
[foo2 = { name: "something" }]
[ foo3 = ::std::Foo { name: "something" }]
[ ::std::Foo { name: "something" }]
[std::Foo { name: "something" },
 Foo { name: "something" },
 Foo]
scope
{

}

/*********************
    Generic Types
**********************/
def struct GenericStructWithSimpleTypeParameter<TString>
{
    field1: TString
}

def struct GenericStructWithMultipleTypeParameter<TString, TFoo, TBar>
{
}

def enum struct GenericEnumStructWithSimpleTypeParameter<TString>
{
    Foo
    {
        field1: TString
    }
}

def enum struct GenericEnumStructWithMultipleTypeParameter<TString, TFoo, TBar>
{
}

def enum GenericEnumWithSimpleTypeParameter<TString>
{
}

def enum GenericEnumWithMultipleTypeParameter<TString, TFoo, TBar>
{
}


/*********************
    Scoped imports

** --------------------------------**
Assume a folder structure as follows:

Root
└── Foo
    ├── FooStruct1.ddl
    ├── FooStruct2.ddl
    └── Bar
        ├── BarStruct1.ddl
        ├── BarStruct2.ddl
        └── Baz
            ├── BazStruct1.ddl
            └── BazStruct2.ddl
** --------------------------------**

**********************/

scope
{
    // 1. Places the Foo root namespace in scope
    import ::Foo;

    // 2. Places the FooStruct1 type in scope
    import ::Foo::FooStruct1;

    // 3. Places the group with FooStruct2 type in scope
    import ::Foo::{ FooStruct2 };    

    // 4. Places the FooStruct3 type in scope with alias
    import ::Foo::FooStruct3 as AwesomeFooStruct;
    
    // 5. Places the group with FooStruct4 type in scope with alias
    import ::Foo::{ FooStruct4 as SuperFooStruct };

    def struct ScopedStruct1 {
        // Uses type imported by (2)
        foo1: FooStruct1,

        // Uses type based on namespace imported by (1)
        foo2: Foo::FooStruct2,
        // Uses type imported by (3)
        foo3: FooStruct2,

        // Uses type based on root namespace
        foo4: ::Foo::FooStruct3,
        
        // Uses type based on alias introduced by (4)
        foo5: AwesomeFooStruct,

        // Uses type based on alias introduced by (5)
        foo6: SuperFooStruct,
    }
    
    scope {
        // 6. Places the CoolBaz alias as Foo namespace in scope, based on import (1)
        import Foo as CoolBaz;
        
        // 7. Places the CoolBaz alias as Foo::Bar root namespace in scope
        import ::Foo::Bar as UncoolBaz;

        // 6. Places the Foo::Bar root namespace in scope
        import ::Foo::Bar;        
        // 7. Places the Foo::Bar namespace in scope, based on import (1)
        import Foo::Bar2;
        // 8. Places the BarStruct1 type in scope, based on import (1)
        import Foo::Bar::BarStruct1;
        // 9. Places the BarStruct2 type in scope, based on root namespace
        import ::Foo::Bar::BarStruct2;
        // 10. Places the BarStruct3 type in scope with alias, based on import (1)
        import Foo::Bar::BarStruct3 as FantasticBarStruct;
        // 11. Places the BarStruct4 type in scope with alias, based on root namespace
        import ::Foo::Bar::BarStruct4 as MegaBarStruct;

        def struct ScopedStruct2 {
            bar1: BarStruct1,
            bar2: Bar::FooStruct2,
            bar2: Foo::FooStruct2,
            bar2: Foo::Bar::FooStruct2,
            bar3: ::Foo::Bar::FooStruct3,
            bar4: FantasticBarStruct,
            bar5: MegaBarStruct,
        }        

        def struct ScopedStruct3 {
            // Uses type imported by (2)
            foo1: FooStruct1,

            // Uses type based on namespace imported by (1)
            foo2: Foo::FooStruct5,

            // Uses type imported by (3)
            foo3: FooStruct2,

            // Uses type based on root namespace
            foo4: ::Foo::FooStruct6,
            
            // Uses type based on alias introduced by (4)
            foo5: AwesomeFooStruct,

            // Uses type based on alias introduced by (5)
            foo6: SuperFooStruct,

            // Uses type based on aliased namespace imported by (1)
            foo2: CoolBaz::FooStruct7,
        }
    }
    
    scope {
        def struct ScopedStruct4 {
            // Uses type imported by (2)
            foo1: FooStruct1,

            // Uses type based on namespace imported by (1)
            foo2: Foo::FooStruct2,
            // Uses type imported by (3)
            foo3: FooStruct2,

            // Uses type based on root namespace
            foo4: ::Foo::FooStruct3,
            
            // Uses type based on alias introduced by (4)
            foo5: AwesomeFooStruct,

            // Uses type based on alias introduced by (5)
            foo6: SuperFooStruct,
        }
    }
}



/*********************
    Enum Types
**********************/
def enum struct ConstantValue
{
    Unit,
    Bool {
        value: scalar::bool,
    }
    Int {
        value: u32
    }   
    Float {
        value: f32
    }
    Vector2 {
        value: vec2::f32
    }
    Vector3 {
        value: vec3::f32
    }
    Vector4 {                  
        value: vec4::f32
    }
}

def enum TextureType
{
    Unknown,
    Texture2D,
    Texture3D,
    TextureCube
}