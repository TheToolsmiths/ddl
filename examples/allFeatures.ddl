// README: This file is meant to have all the grammar features and serve as a test case
/******/

;;;;;;

/***************
**  Imports   ** 
***************/
import export1 from "module-name";
import * as name from "module-name";
import export1 as name from "module-name";
import { export1 } from "module-name";
import { export1 as alias1 } from "module-name";
import { export1, export2 } from "module-name";
import { foo , bar } from "module-name/path/to/specific/un-exported/file";
import { export1 , export2 as alias2 } from "module-name";
import { export1 } from "module-name";

;;


def struct StructWithArrayField
{
    field1: ref std::experimental::TestFieldType<Foo>[][20][20, 45, 0x02],
    
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

// Empty Scope
scope
{        
}

// Empty Scope With Conditional Expression
scope ((DEFINE_1 && ((DEFINE_2 != "Something") && DEFINE_3 == "Something else"))|| false)
{        
};;;;

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

def struct GenericStructWithSimpleTypeParameter<TString>
{
}

def struct GenericStructWithMultipleTypeParameter<TString, TFoo, TBar>
{
}
