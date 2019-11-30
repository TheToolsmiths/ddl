using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models
{
    public class StructValueInitialization : ValueInitialization
    {
        public StructValueInitialization(IEnumerable<FieldValueInitialization> fields)
        {
            Fields = fields;
        }

        public override ValueInitializationType Type => ValueInitializationType.Struct;

        public IEnumerable<FieldValueInitialization> Fields { get; }

        public new static StructValueInitialization CreateEmpty()
        {
            return new StructValueInitialization(Array.Empty<FieldValueInitialization>());
        }
    }
}
