// No comma on last field and no comma after scope
def struct TestStructType
{
    scope(Define1 && !((!Define2) || false ))
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32
    }
}

// No comma on last field and no comma after scope
def struct TestStructType
{
    scope(true || false)
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32,
    }
}

// No comma on last field and comma after scope
def struct TestStructType
{
    scope( Define1 != "Something" || false && true || false || Define2)
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32
    },
}

// No comma on last field and comma after scope
def struct TestStructType
{
    scope(!Define1  && false )
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32,
    },
}
