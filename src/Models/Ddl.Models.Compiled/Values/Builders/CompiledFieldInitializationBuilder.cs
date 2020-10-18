using System;

namespace TheToolsmiths.Ddl.Models.Compiled.Values.Builders
{
    public class CompiledFieldInitializationBuilder
    {
        public CompiledFieldInitializationBuilder(string fieldName, CompiledInitializationBuilder initializationBuilder)
        {
            this.InitializationBuilder = initializationBuilder;
            this.FieldName = fieldName;
        }

        public string FieldName { get; set; }

        public CompiledInitializationBuilder InitializationBuilder { get; }

        public CompiledFieldInitialization Build()
        {
            var fieldName = this.FieldName ?? throw new NotImplementedException();

            var initialization = this.InitializationBuilder.Build();

            return new CompiledFieldInitialization(fieldName, initialization);
        }

        public CompiledFieldInitializationBuilder WithName(string fieldName)
        {
            this.FieldName = fieldName;

            return this;
        }
    }
}
