// Struct with three fields
def struct TestStructType
{
    [key = "TestValue"]
    [key = TestAttributeType]
    [key = TestAttributeType {}]
    [TestAttributeType]
    [TestAttributeType {}]
    [TestAttributeType { value1: false, value2: 10 }]
    [TestAttributeType { struct1: {value1: false, value2: 10 }}]
    field5: TestFieldType,
}
