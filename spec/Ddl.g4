grammar Ddl;

// ###	Parser  ###

// Struct definition
defStruct: attrBlockList defStructHeader defStructBody;

defStructHeader: 'def' 'struct' typeIdent;

defStructBody: '{' ( structField ( ',' structField)* ','?)? '}';

structField: fieldIdent ':' typeIdent fieldInitialization?;

fieldInitialization: '=' (Literal | structInitialization);

typeIdent: Ident;

fieldIdent: Ident;

// Struct Initialization
structInitialization:
	'{' (
		structFieldInitialization (',' structFieldInitialization)* ','?
	)? '}';

structFieldInitialization:
	fieldIdent ':' (Literal | structInitialization);

// Attributes
attrBlockList: (attrBlock)*;

attrBlock: '[' ( attrUse ( ',' attrUse)* ','?) ']';

attrUse: keyedAttrUse | typedAttrUse;

keyedAttrUse: Ident '=' (Literal | typedAttrUse);

typedAttrUse: Ident structInitialization?;

// ###	Lexer  ###

// Boolean
Literal:
	('-' | '+')? IntLit
	| ('-' | '+')? FloatLit
	| ( StrLit | BoolLit);

BoolLit: 'true' | 'false';

IntLit: DecimalLit | OctalLit | HexLit;

// Integer literals
fragment DecimalLit: [1-9] DecimalDigit*;

fragment OctalLit: '0' OctalDigit*;

fragment HexLit: '0' ('x' | 'X') HexDigit+;

// Floating-point literals
FloatLit: (
		Decimals '.' Decimals? Exponent?
		| Decimals Exponent
		| '.' Decimals Exponent?
	)
	| 'inf'
	| 'nan';

fragment Decimals: DecimalDigit+;

fragment Exponent: ('e' | 'E') ('+' | '-')? Decimals;

// String literals
StrLit: '\'' CharValue* '\'' | '"' CharValue* '"';

fragment CharValue:
	HexEscape
	| OctEscape
	| CharEscape
	| ~[\u0000\n\\];

fragment HexEscape: '\\' ('x' | 'X') HexDigit HexDigit;

fragment OctEscape: '\\' OctalDigit OctalDigit OctalDigit;

fragment CharEscape: '\\' [abfnrtv\\'"];

// Empty Statement
emptyStatement: ';';

// Letters and digits
fragment Letter: [A-Za-z_];

fragment DecimalDigit: [0-9];

fragment OctalDigit: [0-7];

fragment HexDigit: [0-9A-Fa-f];

// Identifiers
Ident: Letter (Letter | DecimalDigit)*;

// Whitespaces
WhiteSpace: [ \t\r\n] -> skip;
