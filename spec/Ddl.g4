grammar DdlParser;

/***********
** Parser **
************/

// Struct definition
def_struct: 'def' 'struct' TYPE_IDENTIFIER '{' (struct_field ( ',' struct_field )* ','?)? '}';

struct_field: IDENTIFIER ':' TYPE_IDENTIFIER ('=' struct_initialization)?;

struct_initialization: '{' (struct_field_initialization ( ',' struct_field_initialization )* ','?)? '}';

struct_field_initialization: IDENTIFIER ':' (LITERAL_VALUE | struct_initialization);

/***********
**  Lexer **
************/
IDENTIFIER : [a-zA-Z_] [a-zA-Z0-9_]* ;

TYPE_IDENTIFIER : IDENTIFIER ;

LITERAL_VALUE: IDENTIFIER ; // TODO

WHITESPACE : [ \t\r\n] -> skip ;
