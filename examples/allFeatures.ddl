[key = "TestValue"]
def struct EmptyStruct
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
        field1: TestFieldType
    }
}

[TestAttributeType { value1: false, value2: 10 }]
def struct StructWithScopes
{
    // Scope
    scope
    {        
        field1: TestFieldType
    }

    // Scope With Conditional Expression
    scope ( Define1 != "Something" || false && true || false || Define2)
    {        
        [TestAttributeType { struct1: {value1: false, value2: 10 }}]
        field1: TestFieldType,

        [Conditional(Define1 || (false || true))]
        field2: bool,
        field3: i32,
    }
}
}

def struct StructWithFieldsAndScopes
{
    field1: TestFieldType,
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
        field5: TestFieldType,
        field6: bool,
    }

    field1: TestFieldType,
}

def struct StructWithMultipleFields
{    
    [TestAttributeType { struct1: {value1: false, value2: 10 }}]
    field1: TestFieldType,
    field2: bool,
    field3: i32,
}
