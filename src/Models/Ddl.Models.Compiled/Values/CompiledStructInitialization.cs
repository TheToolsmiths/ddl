using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class CompiledStructInitialization : CompiledValueInitialization
    {
        public CompiledStructInitialization(IReadOnlyList<CompiledFieldInitialization> fields)
        {
            this.Fields = fields;
        }

        public override CompiledValueInitializationType InitializationKind => CompiledValueInitializationType.Struct;

        public IReadOnlyList<CompiledFieldInitialization> Fields { get; }

        public new static CompiledStructInitialization CreateEmpty()
        {
            return new CompiledStructInitialization(Array.Empty<CompiledFieldInitialization>());
        }
    }
}
