# Conditional Expressions

Conditional expressions are booleans expressions made of one or logical combinations of expressions, symbol expressions or boolean literals.


## Expressions

Expressions can be a single `symbol expression`, a single boolean literal, or a combination of several expressions.


## Expression combination

Two expressions can be logically combined using either `||` as the `OR` operator, or `&&` as the `AND` operator.
Two logically combined expressions result in a new expression.

Examples:
    
    TEST_SYMBOL == "test123" || TEST_SYMBOL != "some other value"
    
    TEST_SYMBOL == "test123" && (TEST_SYMBOL != "some other value")


## Expression negation

A single expression can be preceeded by `!` where it negates the expression value. Like with expression combination, negating an expression results in a new expression.

Example:
    
    !(TEST_SYMBOL == "test123")


## Boolean literal expressions

In place of an expression, a boolean literal, `true` or `false`, can also be used.


## Symbol names

A `symbol` name starts with a lower-case or upper-case letter, and is followed by any number of letters, numbers or `_` (underscore). Their lookup from the provided set is case-sensitive.


## Symbol definitions

A `symbol` can either be defined or not defined, that is, it can either be present on the provided set or not.
It can also have a string value. An empty string value also sets the `symbol` as defined.


## Symbol evaluation

A `symbol` can be used to build an expression in the following ways

### Single symbol usage

Used by itself where its evaluated if the `symbol` is defined, but the `symbol`'s value is ignored
    
Example:
    
    TEST_SYMBOL

### Symbol negation

Used preceeded by `!` where its evaluated to true if the `symbol` is not defined
    
Example:
    
    !TEST_SYMBOL

### Symbol and string constant comparison

Compared against a string constant where the expression evaluates to true or false depending on wether the `symbol` is defined or not and its value.

A `symbol` can be compared against the string constant using the following operators:

- Using `==` to test if the `symbol` is defined and has the same value as the string constant

    Example:

        TEST_SYMBOL == "test123"

- Using `!=` to test if the `symbol` is not defined or does not have the same value as the string constant

    Example:

        TEST_SYMBOL != "test123"
