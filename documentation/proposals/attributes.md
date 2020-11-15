# Attributes

Attributes are metadata that can be associated with the following `ddl` elements:
- Type definitions
- Type definition's fields
- Scopes

## Attribute usage

Altho the syntax details are still up for working, their usage should be flexible enough to support any current scenario supported by other ddls.

For this we propose to support two types of usage:

### Value usage

Attribute is used as a single value of any of the supported types. It is meant for typed attributes, while primitive types are not allowed.

Examples:
- `[TypedAttribute { foo = false, bar = 42}]`

Not allowed:
- `["some text"]`

### Keyed usage

Similar to value usage, but any attribute usage is preceded by a key. Supports all types. Mostly useful for primtiive types, but for completeness it also supports typed attributes.

Examples:

- `[foo = "some text"]`
- `[bar = TypedAttribute { foo = false, bar = 42}]`


## Supported types

For attribute usage we support all primitive types that support a literal usage, such as:
- number types, i.e., ints, floats
- booleans
- strings

Primitive types not supported:
- references

We also support typed attributes, which are compounds of the primitive types above, or other typed attributes.


## Typed attribute declaration

Typed attributes are declared as normal types.

To aid tooling, attributes should be marked with an attribute tag `[attribute]`, and if they're meant to only be used as attribute they should be tagged with an attribute `[attribute_only]`, or inversely `[not_attribute]` to avoid use the type as attribute.
This should help in scenarios where codegen for working with attributes is required, or to help drive tools that need to handle "normal" types and attribute types differently.
This applies only to the root type, i.e., if the type `A` to be used as attribute uses another user defined type `B`, then `B` is not required to be marked with the attribute tagging attributes.


## Uniform usage across the supported scenarios

The attribute usage across the possible scenarios should be the same for all of them, i.e., there shouldn't be a way to use attributes with type definitions and a different one for fields.

## Support xDL compatibility

The `xDL` project idea is to create a meta syntax where new definition languages can be supported on the same file as existing ones.
The details of this initivative are outside of the scope of this document, but it imposes contraints on the attribute syntax.

### Parse complexity
Let's suppose we ended up using an attribute syntax for classes such as:
```
def type UnsuspectedType {
    count: int,
}

def type SomeAttrib
{
    bar: bool,
    baz: UnsuspectedType,
}

def type Foo, SomeAttrib { bar: false, baz: { count: 10 } }
{    
}
```
and the `xDL` spec says that `def type` defines the type of the element to parse, but the current parser cannot parse `def type` statements.
The current parser, as `xDL` compliant, should be able to skip the whole `def type Foo, SomeAttrib {bar: false} {}` block, but since it does not support `def type` statements it needs to be able to skip unknown blocks efficiently.

If the xDL project ended up with a unknow block syntax similar to `(block_keyword)+ id (token0, token1, …, tokenN)+ { (block_content)+ }`, then `SomeAttrib {bar: false}` would end up as a `token`, but the `{bar: false}` part would deceive the parser into thinking its already skipping the `{ (block_content)+ }`, and when it got to the actual `{ (block_content)+ }` it would be seen as garbage, since the parser would be looking for a new statment.

### Possible solutions

#### Trailing semicolon, always!
A possible solution would be to force ending all statements with a semicolon `;`, even if they already end with a block, `{ }`, declaration. It is the easier solution to parse, but I see it as extra pressure on the user and tooling, as little as it might be it adds up, where the user needs to always add it at the end of a block, even if they're not used to it in their primary language, while on the tooling it will be harder to provide meaningful errors in cases where `;` is missing.

#### Inside attributes
Another possible solution is to use attributes inside the block they're targeting. Using the example above it would be something like:
```
def type Foo
{    
    @SomeAttrib { bar: false },
}
```

The major issue with this approach is that it will require a different way to use them with fields, probably like:
```
def type Foo, SomeAttrib { bar: false }
{    
    baz: bool {
        @SomeAttrib { bar: false } 
    },
}
```

This inconsistency will have an impact both on the parser development, and with the learning curve for new users.

#### Embrace your attributes
A third possible solution is to adopt the attribute usage into the `xDL` effort. It makes attributes usable right away for any statement that might make use of them, and reduces the parser tooling effort since it will be shared across projects.

Unfortunately this approach isn't flawless, since it will introduce a hard dependency of the `ddl` effort into the `xDL`, since it will have to be aware of type declaration and usage. But in the end it might not be a blocker at all, and just the foundation for a prosperous ecosystem of languages.
