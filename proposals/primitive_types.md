# Primitive Types

Primitive types are the foundational types provided by the ddl, and are also known as built-in types or fundamental types for other languages.

In the case of the ddl these types are not meant to store data. They're simply placeholders, or in case of the ddl being used for code generation of a target architecture meant to match the types of the target.

There are several categories of primitive types:

- general
    - any

- numerical
    - types
    - scalar
    - vector
    - matrix

- boolean
    - bool

- string
    - string
    - char

## General

These are generic types that do not represent explicit direct data storage properties, like size, endianess, aligment or struct padding, but map directly to equivalent data types in the target platform.

### any

The type `any` represents anything that can be represented in the target platform. 
Since languages like C and C++ can only store concrete types inside a struct or on stack, maybe this type should be restricted to a reference type, `&any`.
The data stored behind it can be anything, such as a primitive type or an object. Similar to `object` or `void*` in other languages.

#### Availability
After some feedback questioning the usability of `any` type, it won't be included in the list of allowed primitive types, but will be kept as a reserved keyword for possible future use.

The following are what can be perceived as main factors to consider the impact of this type of keyword, and if it should be available:

- A keyword like has direct impact on any serialization effort since the type of data it points to is unknown, increasing efforts for generating serializers, or any other serialization methods.

- In case the `ddl` format ends up implementing a shareable format, it increases the burden on the shared format consumer to support an `any` type.

- It allows the format user flexibility to map existing data types to the `ddl` format, and in a way marking the field type as not important.

Since there can be valid points both ways, and its dependent of the user case, we'll keep the `any` type keyword reserved, but can consider allowing it internally to projects, that is, allowed inside the project itself but not on a possible shareable format, if there is feedback that it is useful.

## Numerical

Numerical types represent the storage of numbers. These numbers can be integers or float, signed or unsigned, and have a variable number of bits.

### types

The numerical types provided by the ddl are the following:

- `i8`
- `u8`
- `i16`
- `u16`
- `i32`
- `u32`
- `i64`
- `u64`
- `f16`
- `f32`
- `f64`

Numerical type names have two parts, the prefix is either `i` for integer signed types, `u` for integer unsigned types, or `f` for floating point types. The suffix contains the amounts of bits used to store the type.
Cardinality can be controlled aswell. Compound numerical types, such as vectors or matrices, can be created by namespacing these numerical types.

### scalar

A numerical scalar types have a single value. They can be of any of the numerical types. Additionally they can be namespaced in `scalar` for consistency. 

Example:

    u16
    scalar::f32

### vector

Numerical vector types contain several values in the same dimension. They can also be of any of the numerical types, and are namespaced on `vecN`, where `N` is the number of elements in the vector.

Example:

    vec3::f32
    vec8::u8

## matrix

Numerical mattrix types contain several values in several dimensions. They can also be of any of the numerical types.
Currently they can only be 2D to keep things simple. Matrices are namespaced on `matNxM`, where `N` and `M` is the size of each dimension.

Example:

    mat3x2::i64
    mat8x8::f16

## Boolean

The usual boolean types in most programming languages. Can have the literal value `true` or `false`.

## Text

Types to handle text are essential to programming, and as such common in many languages.
But unlike most languages, these types do not represent any guarantees of encoding, validity, storage types, size encoding, null termination, or even storage method.
All these properties are to be decided and enforced by the target platform.

### char

Represents a single character.

### string

Represents a sequence of one or characters.
