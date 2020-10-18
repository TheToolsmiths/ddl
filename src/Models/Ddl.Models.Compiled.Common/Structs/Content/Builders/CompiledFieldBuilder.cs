using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content.Builders
{
    public class CompiledFieldBuilder
    {
        public CompiledFieldBuilder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public ResolvedTypeUse? TypeReference { get; set; }

        public List<ICompiledAttributeUse> Attributes { get; } = new List<ICompiledAttributeUse>();

        public CompiledValueInitialization Initialization { get; set; } = CompiledValueInitialization.CreateEmpty();

        public CompiledAttributeUseCollection AttributeCollection { get; set; } = CompiledAttributeUseCollection.Empty;

        public CompiledFieldBuilder WithType(ResolvedTypeUse type)
        {
            this.TypeReference = type;

            return this;
        }

        public CompiledFieldBuilder WithName(string name)
        {
            this.Name = name;

            return this;
        }

        public CompiledFieldBuilder AddInitialization(CompiledValueInitialization initialization)
        {
            this.Initialization = initialization;

            return this;
        }

        public CompiledField Build()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new InvalidOperationException();
            }

            var fieldType = this.TypeReference ?? throw new NotImplementedException();

            var attributes = this.AttributeCollection;

            var initialization = this.Initialization;

            return new CompiledField(this.Name, fieldType, attributes, initialization);
        }
    }
}
