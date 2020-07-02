﻿using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class KeyedTypedAttributeUse : BaseTypedAttributeUse, IKeyedTypedAttributeUse
    {
        public KeyedTypedAttributeUse(string key, TypeReference type, StructInitialization initialization)
            : base(type, initialization)
        {
            this.Key = key;
        }

        public KeyedTypedAttributeUse(string key, TypedStructInitialization initialization)
            : this(key, initialization.Type, initialization.Initialization)
        {
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public string Key { get; }
    }
}