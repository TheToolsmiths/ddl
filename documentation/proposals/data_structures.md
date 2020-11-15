# Data Structures

The definition of data structures and the fields they contain is the main use case for DDL systems.

## Definition
A data structure can be defined with

```
def struct Foo
{
    [....]
}
```

It follows the normal C-like structure definition, with the addition of the `def` keyword.

This `def` keyword is used to make it explicit we are defining a new structure of type `Foo`. Unlike C where this is implicit from the syntax, using an explicit keyword makes it easier to parse.
Besides being useful for parsing, it also makes it future-proof in case we need to add support, for example, extending the struct declaration with attributes, or overrides per-scenario.

Example (with placeholder syntax)
```
[override(DEBUG)]
ext struct Foo
{
    {...this.fields},
    counter: int,
}
```

In this example the struct `Foo` adds an additional `counter` field if compiled to `DEBUG`.

__NOTE__: This syntax is purely for the example sake. Don't focus too much in it :)

## Fields

A data structure can contain a list of fields. Each field is defined by a name and a type.
The field items are separated by `,` with an optional `,` at the end to make text editing easier.

Example:

```
def struct Foo
{
    bar: int,
    baz: string,
}
```

Lately two ways to define fields have become mainstream. The C-like way of `type name`, and other of `name: type`.

C-like has always been a common occurrence in programming, but the latter option might be simpler to parse. Also allows for typeless fields, in case thats is required.

## Attributes

Both structure definitions and field definitions can have attributes applied to them. They follow the standard attribute rules where the attribute is placed before the struct or field definition.

Structure definition with attribute example:
```
[TestAttribute]
def struct TestType
{
    bar: int,
    baz: string,
}
```

Field definition with attribute example:
```
def struct TestType
{
    [TestAttribute] bar: int,
    [key = KeyedTestAttribute] baz: string,
}
```
