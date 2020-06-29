using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Values
{
    public class StructInitialization : ValueInitialization
    {
        public StructInitialization(IReadOnlyList<FieldInitialization> fields)
        {
            this.Fields = fields;
        }

        public override ValueInitializationType InitializationKind => ValueInitializationType.Struct;

        public IReadOnlyList<FieldInitialization> Fields { get; }

        public new static StructInitialization CreateEmpty()
        {
            return new StructInitialization(Array.Empty<FieldInitialization>());
        }
    }
}
