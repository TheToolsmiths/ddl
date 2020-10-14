﻿using TheToolsmiths.Ddl.Models.Compiled.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class KeyedLiteralAttributeUse : BaseAttributeUse, IKeyedLiteralAttributeUse
    {
        public KeyedLiteralAttributeUse(string key, LiteralValue literal)
        {
            this.Key = key;
            this.Literal = literal;
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedLiteral;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public string Key { get; }

        public LiteralValue Literal { get; }
    }
}
