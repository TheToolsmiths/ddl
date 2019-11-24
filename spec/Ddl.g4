grammar Ddl;

// ###	Parser  ###

// File contents
fileContents: (defStruct | fileScope)*;

// Scopes
fileScope:
	Scope ('(' conditionalExpression ')')? '{' fileContents '}';

structScope:
	Scope ('(' conditionalExpression ')')? '{' defStructContents '}';

// Type usage
typeIdent: ( Identifier NamespaceSeparator)* Identifier;

typeName: Identifier;

// Struct definition
defStruct:
	attrUseList 'def' 'struct' typeName '{' defStructContents? '}';

defStructContents:
	(structField | structScope) ((',' structField) | (','? structScope))* ','?;

structField:
	attrUseList fieldName ':' typeIdent ('=' valueInitialization)?;

fieldName: Identifier;

// Value Initialization
valueInitialization: (Literal | structValueInitialization);

structValueInitialization:
	'{' (
		fieldValueInitialization (',' fieldValueInitialization)* ','?
	)? '}';

fieldValueInitialization: fieldName ':' valueInitialization;

// Attributes
attrUseList: ('[' ( attrUse ( ',' attrUse)* ','?) ']')*;

attrUse: keyedAttrUse | typedAttrUse;

keyedAttrUse: Identifier '=' (Literal | typedAttrUse);

typedAttrUse: typeIdent structValueInitialization?;

// Conditional Expressions
conditionalExpression:
	| conditionalExpression ('||' | '&&') conditionalExpression
	| '!' conditionalExpression
	| conditionalSymbolExpression
	| BoolLit;

conditionalSymbolExpression:
	conditionalSymbolComparison
	| conditionalSymbolNegation
	| Identifier;

conditionalSymbolNegation: '!' Identifier;

conditionalSymbolComparison: Identifier ('==' | '!=') StrLit;

// ###	Lexer  ###

// Boolean
Literal:
	('-' | '+')? IntLit
	| ('-' | '+')? FloatLit
	| ( StrLit | BoolLit);

BoolLit: 'true' | 'false';

IntLit: DecimalLit | HexLit;

// Types fragments
NamespaceSeparator: '::';

// Integer literals
fragment DecimalLit: [1-9] DecimalDigit*;

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

fragment CharValue: HexEscape | CharEscape | ~[\u0000\n\\];

fragment HexEscape: '\\' ('x' | 'X') HexDigit HexDigit;

fragment CharEscape: '\\' [abfnrtv\\'"];

// Letters and digits
fragment Letter: [A-Za-z_];

fragment DecimalDigit: [0-9];

fragment OctalDigit: [0-7];

fragment HexDigit: [0-9A-Fa-f];

fragment Underscore: '_';

// Keywords
Scope: 'scope';

// Identifiers
Identifier: Letter (Letter | DecimalDigit | Underscore)*;

// Whitespace and comments
WhiteSpace: [ \t\r\n] -> skip;

Comment: '/*' .*? '*/' -> skip;

LineComment: '//' ~[\r\n]* -> skip;
