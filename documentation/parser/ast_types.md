# AST Types

In the AST types are represented by two root interfaces


### Type Name

Are used to indentify declared types.

They can be of two types:

#### Simple TypeName

Have a single identifier corresponding to the Type's name.

#### Generic TypeName

Have a single identifier corresponding to the Type's name, and a list of one or more identifiers, corresponding to the name of the generic parameters.


### Type Identifier

Are used to identify and reference existing types, while also providing concrete values for generic parameters.

They can be:

#### Qualified Type

Contains a Type Identifier Path to the type that is being identified.

#### Array Type

Contains a Qualified Type and a list of one or more Array Sizes. Each Array Size can have a constant size, or be dynamic where no constant size is specified.

#### Reference Type

Contains a Referenciable Type and the Reference Kind.

A Reference can be of the following kinds:

##### Owns
The referenced instance is owned by this type usage place.
Uses `owns` as syntax keyword.

##### Handle
The target instance is not referenced directly, but thru a handle id.
Uses `handle` as syntax keyword.

##### Reference
The referenced instance is referenced directly by this type usage place, but no ownership is assumed.
Uses `ref` as syntax keyword.

#### Generic Parameter Types

A Generic Parameter restricts the kind of types it supports.
These are:
- Qualified Type
- Array Type
- Reference Type

### Type Identifier Path

A Type Identifier Path contains a sequence of parts.
Each part can be one of two types:

#### Simple Identifier Path Part

Have a single identifier corresponding to the Type Part's name.

#### Generic Identifier Path Part

Have a single identifier corresponding to the Type Part's name, and a list of one or more Generic Parameter Types, corresponding to the value each of the generic parameters will take.

