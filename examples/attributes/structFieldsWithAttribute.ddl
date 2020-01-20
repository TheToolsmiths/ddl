// Struct with single field 
def struct TestStructType
{
    [key = "TestValue"]
    field1: TestFieldType,

    [key = TestAttributeType]
    field2: TestFieldType,

    [key = TestAttributeType {}]
    field3: TestFieldType,

    [TestAttributeType]
    field4: TestFieldType,

    [TestAttributeType {}]
    field5: TestFieldType,

    [TestAttributeType { value1: false, value2: 10 }]
    field6: TestFieldType,

    [TestAttributeType { struct1: {value1: false, value2: 10 }}]
    field7: TestFieldType,
    
    [ConditionalAttributeType(FOO || BAR)]
    field8: TestFieldType,
}