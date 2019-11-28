grammar Ddl;

// ###	Parser  ###

// File contents
fileContents: (defStruct | fileScope)*;

// Scopes
fileScope:
	Scope ('(' conditionalExpression ')')? '{' fileContents '}';

structScope:
	Scope ('(' conditionalExpression ')')? '{' defStructContents? '}';

// Type usage
typeIdent: ( Identifier NamespaceSeparator)* Identifier;

typeName: Identifier;

// Struct definition
defStruct:
	attrUseList 'def' 'struct' typeName '{' defStructContents? '}';

defStructContents:
	structScope ','? defStructContents?
	| structField ','? structScope ','? defStructContents?
	| structField (',' structField)* ','? structScope ','? defStructContents?
	| structField (',' structField)* ','?
	| structScope ','?
	| structField ','?
	| structScope
	| structField
	;

structField:
	attrUseList fieldName ':' typeIdent ('=' valueInitialization)?;

fieldName: Identifier;

// Value Initialization
valueInitialization: (literalValue | structValueInitialization);

structValueInitialization:
	'{' (
		fieldValueInitialization (',' fieldValueInitialization)* ','?
	)? '}';

fieldValueInitialization: fieldName ':' valueInitialization;

// Attributes
attrUseList: ('[' ( attrUse ( ',' attrUse)* ','?) ']')*;

attrUse: keyedAttrUse | typedAttrUse;

keyedAttrUse: Identifier '=' (literalValue | typedAttrUse);

typedAttrUse: typeIdent structValueInitialization?;

// Conditional Expressions
conditionalExpression:
	'(' conditionalExpression ')'												# ParenthesisExpression
	| conditionalExpression ConditionalLogicalOperator conditionalExpression	# BinaryExpression
	| BoolLiteral																# BoolLiteralExpression
	| conditionalSymbolExpression												# SymbolExpression
	| '!' conditionalExpression													# NegateExpression
	;

// Conditional Symbols
conditionalSymbolExpression:
	conditionalSymbolComparison	# CompareSymbols
	| conditionalSymbolNegation	# NegateSymbol
	| Identifier				# IdentifierSymbol;

conditionalSymbolNegation: '!' Identifier;

conditionalSymbolComparison:
	Identifier EqualityComparerOperator StringLiteral;

// Literal rules
literalValue:
	('-' | '+')? IntLiteral		# IntegerLiteral
	| ('-' | '+')? FloatLiteral	# FloatLiteral
	| BoolLiteral				# BoolLiteral
	| StringLiteral				# StringLiteral;

// ###	Lexer  ###

ConditionalLogicalOperator: '||' | '&&';

EqualityComparerOperator: '==' | '!=';

// Boolean
BoolLiteral: 'true' | 'false';

IntLiteral: DecimalLiteral | HexLiteral;

// Types fragments
NamespaceSeparator: '::';

// Integer literals
fragment DecimalLiteral: DecimalDigit+;

fragment HexLiteral: '0' ('x' | 'X') HexDigit+;

// Floating-point literals
FloatLiteral: (
		Decimals '.' Decimals? Exponent?
		| Decimals Exponent
		| '.' Decimals Exponent?
	)
	| 'inf'
	| 'nan';

fragment Decimals: DecimalDigit+;

fragment Exponent: ('e' | 'E') ('+' | '-')? Decimals;

// String literals
StringLiteral: ('\'' CharValue* '\'') | ('"' CharValue* '"');

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
