# Field Initializers

Field initializers, aka default values, allow to declare an initial value to a field in it's declaration.

Field initializers are used after a field declaration but before the field list separator `,` and are preceded by `=`.

Fields of primitive types can be initialized by a literal supported by that type, while custom types will use structure initialization.

Example:
```
def struct Unit
{
    hp: u32 = 10,
    active: bool = false,
}
```

## Structured initialization

Structured initialization is used to initialize fields of data types.

It is composed of a list of the data type fields, each with its own initializer.

It uses `{` and `}` as delimiters, and `,` as field item list delimiter.

Example:
```
def struct SomeUnit
{
    level: u32 = 5;
    charge: f32 = 0.5;
    unit: Unit = { hp = 150, active = true },
}
```

## Optional initialization

It can be a burden to initialize all the defined fields on all structs. For this initialization will be optional.

Optional initialization also means we need to have an expected chain of initialization, i.e., it should be obvious what the default value will end up being.


### Primitive optional initialization

For primitive fields they'll take their type default value, numbers initialized to 0, bools to false, strings to empty, etc., with more detail on the built-in types section.


### Struct optional initialization

For struct types they take the struct's field initialization value, and then fall back to the field's type default value.

Using the previous struct `SomeUnit` as an example here's how the initialization values for all fields would be derived:

```
def struct SomeUnit
{
    level: u32;
    unit: Unit = { hp = 150, active },
}
```

- level -> u32 default value -> 0
- unit  -> `Unit` default initialization:
    - hp -> Direct initialization value -> 150
    - active -> `Unit`'s field `active` initialization value -> false

For the parser library might be useful to add a way to expose this initialization chain.