// No comma after scope
def struct TestStructType
{
    scope ()
    {
    }    
    field1: TestFieldType,
    field2: bool,
    field3: i32
}

// Comma after scope
def struct TestStructType
{
    scope
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
    scope ()
    {
    },
}

// Comma on field before and comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32,
    scope
    {
    },
}

// No comma on field before and no comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32
    scope
    {
    }
}

// Comma on field before and no comma after scope
def struct TestStructType
{
    field1: TestFieldType,
    field2: bool,
    field3: i32,
    scope ()
    {
    }
}