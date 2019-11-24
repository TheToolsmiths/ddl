// No comma on last field and no comma after scope
def struct TestStructType
{
    scope
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32
    }
}

// No comma on last field and no comma after scope
def struct TestStructType
{
    scope
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32,
    }
}

// No comma on last field and comma after scope
def struct TestStructType
{
    scope
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32
    },
}

// No comma on last field and comma after scope
def struct TestStructType
{
    scope
    {
        field1: TestFieldType,
        field2: bool,
        field3: i32,
    },
}
