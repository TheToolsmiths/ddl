[key1 = false]
[key2 = 10]
[key3 = SomeAttr]
[key4 = SomeAttr {}]
[key5 = SomeAttr {flag: false, bar: { value: 5, name: "test1" }}]
[SomeAttr]
[SomeAttr {}]
[SomeAttr {flag: false, bar: { value: 10, name: "test2" }}]
def struct Bar { 
    foo: int,
    bar: foo::something = {
        a: 5,
        b: {
            c: false
        },
        d: {}
    },

    [valuekey = 10]
    [fieldkey = SomeAttr {flag: false, bar: { value: 5, name: "test1" }}]
    attr_field: SomeOtherType
}

def struct Some_Attr_123 {
    somefield: some_other::type
}