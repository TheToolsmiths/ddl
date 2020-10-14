﻿using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class KeyedStructInitializationAttributeUse : BaseStructInitializationAttributeUse, IKeyedStructInitializationAttributeUse
    {
        public KeyedStructInitializationAttributeUse(string key, StructInitialization initialization)
            : base(initialization)
        {
            this.Key = key;
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedStructInitialization;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public string Key { get; }
    }
}
