using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class StructValueInitialization : ValueInitialization
    {
        public StructValueInitialization(IEnumerable<FieldValueInitialization> fields)
        {
            this.Fields = fields;
        }

        public override ValueInitializationType InitializationKind => ValueInitializationType.Struct;

        public IEnumerable<FieldValueInitialization> Fields { get; }

        public new static StructValueInitialization CreateEmpty()
        {
            return new StructValueInitialization(Array.Empty<FieldValueInitialization>());
        }
    }
}
