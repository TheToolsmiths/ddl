using System;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class TokenMemoryConstants
    {
        public static readonly ReadOnlyMemory<char> OpenScope = new[] { CharConstants.OpenScope };

        public static readonly ReadOnlyMemory<char> CloseScope = new[] { CharConstants.CloseScope };

        public static readonly ReadOnlyMemory<char> OpenAttribute = new[] { CharConstants.OpenAttribute };

        public static readonly ReadOnlyMemory<char> CloseAttribute = new[] { CharConstants.CloseAttribute };

        public static readonly ReadOnlyMemory<char> OpenParentheses = new[] { CharConstants.OpenParentheses };

        public static readonly ReadOnlyMemory<char> CloseParentheses = new[] { CharConstants.CloseParentheses };

        public static readonly ReadOnlyMemory<char> OpenGenerics = new[] { CharConstants.OpenGenerics };

        public static readonly ReadOnlyMemory<char> CloseGenerics = new[] { CharConstants.CloseGenerics };

        public static readonly ReadOnlyMemory<char> OpenArrayDimension = new[] { CharConstants.OpenAttribute };

        public static readonly ReadOnlyMemory<char> CloseArrayDimension = new[] { CharConstants.CloseAttribute };

        public static readonly ReadOnlyMemory<char> Equality = new[] { CharConstants.Equal, CharConstants.Equal };

        public static readonly ReadOnlyMemory<char> Inequality = new[] { CharConstants.Not, CharConstants.Equal };

        public static readonly ReadOnlyMemory<char> BinaryAnd = new[] { CharConstants.And };

        public static readonly ReadOnlyMemory<char> LogicalAnd = new[] { CharConstants.And, CharConstants.And };

        public static readonly ReadOnlyMemory<char> BinaryOr = new[] { CharConstants.Or };

        public static readonly ReadOnlyMemory<char> LogicalOr = new[] { CharConstants.Or, CharConstants.Or };

        public static readonly ReadOnlyMemory<char> ValueAssignment = new[] { CharConstants.Colon };

        public static readonly ReadOnlyMemory<char> NamespaceSeparator = new[] { CharConstants.Colon, CharConstants.Colon };

        public static readonly ReadOnlyMemory<char> ListSeparator = new[] { CharConstants.Comma };

        public static readonly ReadOnlyMemory<char> EndStatement = new[] { CharConstants.Semicolon };

        public static readonly ReadOnlyMemory<char> Slash = new[] { CharConstants.Slash };

        public static readonly ReadOnlyMemory<char> LogicalNot = new[] { CharConstants.Not };

        public static readonly ReadOnlyMemory<char> FieldInitialization = new[] { CharConstants.Equal };

        public static readonly ReadOnlyMemory<char> Asterisk = new[] { CharConstants.Asterisk };

        public static readonly ReadOnlyMemory<char> BooleanTrue = new ReadOnlyMemory<char>("true".ToCharArray());

        public static readonly ReadOnlyMemory<char> BooleanFalse = new ReadOnlyMemory<char>("false".ToCharArray());
    }
}
