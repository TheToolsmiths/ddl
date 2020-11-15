# Conditional Attribute

`Conditional Attribute` is an attribute named `Conditional` that can contains a `Conditional Expression`.

## Usage

A `Conditional Attribute` can be applied to any element that already supports Attributes.

## Syntax

The proposed syntax is the following:

```
def struct Foo 
{
    [Conditional(FEATURE_BAR != "1.0")]
    field1: int,
}
```

## Grammar

To support this use case, the `ddl` grammar needs to be updated to accept constructor parameters besides the current support for structured initialization.