using System;

namespace TheToolsmiths.Ddl.Models.Build.Values.Builders
{
    public class FieldInitializationBuilder
    {
        public FieldInitializationBuilder(string fieldName, InitializationBuilder initializationBuilder)
        {
            this.InitializationBuilder = initializationBuilder;
            this.FieldName = fieldName;
        }

        public string FieldName { get; set; }

        public InitializationBuilder InitializationBuilder { get; }

        public FieldInitialization Build()
        {
            var fieldName = this.FieldName ?? throw new NotImplementedException();

            var initialization = this.InitializationBuilder.Build();

            return new FieldInitialization(fieldName, initialization);
        }

        public FieldInitializationBuilder WithName(string fieldName)
        {
            this.FieldName = fieldName;

            return this;
        }
    }
}
