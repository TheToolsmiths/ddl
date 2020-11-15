# Scopes

`Scopes` are blocks that contain elements, and have an optional condition.
When the condition is true, the elements inside the `Scope` are defined, otherwise they will not be part of the evaluated tree.


## Scope definition
A `Scope` can be defined with
```
scope (CONDITION)
{
    [....]
}
```
where `CONDITION` is a conditional expression,

or it can be defined just with
```
scope
{
    [....]
}
```
where it will always be evaluated.

## Usages

A `Scope` block  can be used directly in the file content root, or inside a `struct` block.


## Allowed content

The contents allowed inside a block depend where this are declared.
A `Scope` declared at the file content root allows declaration of the same elements as if it was directly at the file content root, more specifically `def struct` blocks.
While `Scope` blocks inside struct definitions only allow declaration of struct fields.
