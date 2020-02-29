// README: This file is meant to have all the grammar features and serve as a test case

/***************
Sample Block Comment
***************/
[key = "TestValue"]
def struct EmptyStruct
{

}

/*def 
struct /*Foo  EmptyStructOnMultipleLines*/

def 
struct /*Foo */
 EmptyStructOnMultipleLines
{
// Foo

}

def struct EmptyStructOnMultipleLines
{

}

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
scope (Define1 && ((Define2 != "Something") || false ))
{        
}

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

[TestAttributeType { value1: false, value2: 10 }]
def struct StructWithScopes
{
    // Scope
    scope
    {        
        field1: TestGenericType<Foo>
    }

    // Scope With Conditional Expression
    scope ( Define1 != "Something" || false && true || false || Define2)
    {        
        [TestAttributeType { struct1: {value1: false, value2: 10 }}]
        field1: ref test::Map<string<foo>, test::Bar>,

        [IgnoreWhen(Define1 || (false || true))]
        field2: bool,
        field3: i32,
    }   
}

def struct StructWithFieldsAndScopes
{
    field1: handle TestFieldType,
    field2: bool,
    field3: i32

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

def struct GenericStructWithSimpleTypeParameter<string>
{
}

def struct GenericStructWithMultipleTypeParameter<string, int, std::Foo, std::experimental::Bar>
{
}
