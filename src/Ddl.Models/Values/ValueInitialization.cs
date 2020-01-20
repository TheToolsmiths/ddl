﻿using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Values
{
    public abstract class ValueInitialization
    {
        public abstract ValueInitializationType Type { get; }

        public static ValueInitialization CreateEmpty()
        {
            return new EmptyValueInitialization();
        }

        public static ValueInitialization CreateLiteral(LiteralValue literal)
        {
            return new LiteralValueInitialization(literal);
        }
    }
}