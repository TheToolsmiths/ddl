// No comma after scope
def struct TestStructType
{
    scope( Define1 != "Something" || false && true || false || Define2)
    {
    }    
    field1: TestFieldType,
    field2: bool,
    field3: i32
}

// Comma after scope
def struct TestStructType
{
    scope(!false)
    {
    },
    field1: TestFieldType,
    field2: bool,
    field3: i32
}

// No comma on field before and comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32
    scope(!Define1  && false )
    {
    },
}

// Comma on field before and comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32,
    scope(true || false)
    {
    },
}

// No comma on field before and no comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32
    scope(Define1 && !((!Define2) || false ))
    {
    }
}

// Comma on field before and no comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32,
    scope(Define1 && ((Define2 != "Something") || false ))
    {
    }
}