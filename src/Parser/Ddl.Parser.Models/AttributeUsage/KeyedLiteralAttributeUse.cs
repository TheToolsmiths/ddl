﻿using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public class KeyedLiteralAttributeUse : BaseAttributeUse, IKeyedLiteralAttributeUse
    {
        public KeyedLiteralAttributeUse(Identifier key, LiteralValue literal)
        {
            this.Key = key;
            this.Literal = literal;
        }

        public override AttributeUseType UseType => AttributeUseType.KeyedLiteral;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }

        public LiteralValue Literal { get; }
    }
}