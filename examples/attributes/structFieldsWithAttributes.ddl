// Struct with single field 
def struct TestStructType
{
    [key = "TestValue"]
    [key = TestAttributeType]
    [key = TestAttributeType {}]
    field3: TestFieldType,

    [TestAttributeType]
    [TestAttributeType {}]
    field5: TestFieldType,

    [TestAttributeType { value1: false, value2: 10 }]
    [TestAttributeType { struct1: {value1: false, value2: 10 }}]
    field5: TestFieldType,
}