﻿using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public class KeyedStructInitializationAttributeUse : BaseStructInitializationAttributeUse, IKeyedStructInitializationAttributeUse
    {
        public KeyedStructInitializationAttributeUse(Identifier key, StructValueInitialization initialization)
            : base(initialization)
        {
            this.Key = key;
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedStructInitialization;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }
    }
}
