﻿using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumConstantDefinition
    {
        public EnumConstantDefinition(SimpleTypeNameIdentifier name, LiteralValue value)
        {
            this.Name = name;
            this.Value = value;
        }

        public SimpleTypeNameIdentifier Name { get; }

        public LiteralValue Value { get; }
    }
}
