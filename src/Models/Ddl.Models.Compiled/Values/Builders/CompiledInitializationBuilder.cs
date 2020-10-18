using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.Values.Builders
{
    public class CompiledInitializationBuilder
    {
        private CompiledInitializationBuilder(CompiledValueInitializationType initializationType)
        {
            this.InitializationType = initializationType;
            this.Fields = new List<CompiledFieldInitializationBuilder>();
        }

        public CompiledValueInitializationType InitializationType { get; set; }

        private List<CompiledFieldInitializationBuilder> Fields { get; }

        public LiteralValue? LiteralValue { get; set; }

        public ResolvedTypeUse? TypeReference { get; set; }

        public static CompiledInitializationBuilder StartStructured()
        {
            return new CompiledInitializationBuilder(CompiledValueInitializationType.Struct);
        }

        public static CompiledInitializationBuilder StartLiteral()
        {
            return new CompiledInitializationBuilder(CompiledValueInitializationType.Literal);
        }

        public CompiledEmptyInitialization BuildEmpty()
        {
            if (this.InitializationType != CompiledValueInitializationType.Empty)
            {
                throw new NotImplementedException();
            }

            return new CompiledEmptyInitialization();
        }

        public CompiledLiteralInitialization BuildLiteral()
        {
            if (this.InitializationType != CompiledValueInitializationType.Literal)
            {
                throw new NotImplementedException();
            }

            return new CompiledLiteralInitialization(this.LiteralValue);
        }

        public CompiledStructInitialization BuildStructured()
        {
            if (this.InitializationType != CompiledValueInitializationType.Struct)
            {
                throw new NotImplementedException();
            }

            var fields = this.Fields.Select(f => f.Build()).ToList();

            return new CompiledStructInitialization(fields);
        }

        public CompiledTypedStructInitialization BuildTypeIdentifier()
        {
            if (this.InitializationType != CompiledValueInitializationType.TypedStruct)
            {
                throw new NotImplementedException();
            }

            var fields = this.Fields.Select(f => f.Build()).ToList();

            ResolvedTypeUse typeUse = this.TypeReference ?? throw new NotImplementedException();

            var initialization = new CompiledStructInitialization(fields);

            return new CompiledTypedStructInitialization(typeUse, initialization);
        }

        public CompiledValueInitialization Build()
        {
            return this.InitializationType switch
            {
                CompiledValueInitializationType.Empty => this.BuildEmpty(),
                CompiledValueInitializationType.Literal => this.BuildLiteral(),
                CompiledValueInitializationType.Struct => this.BuildStructured(),
                CompiledValueInitializationType.TypedStruct => this.BuildTypeIdentifier(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public CompiledInitializationBuilder WithStructuredField(string fieldName)
        {
            var field = new CompiledFieldInitializationBuilder(fieldName, StartStructured());

            this.Fields.Add(field);

            return field.InitializationBuilder;
        }

        public CompiledInitializationBuilder WithField(string fieldName, bool value)
        {
            var field = new CompiledFieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new BoolLiteral(value));

            return this;
        }

        public CompiledInitializationBuilder WithField(string fieldName, int value)
        {
            var field = new CompiledFieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new NumberLiteral(value));

            return this;
        }

        public CompiledInitializationBuilder WithField(string fieldName, string value)
        {
            var field = new CompiledFieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new StringLiteral(value));

            return this;
        }

        public CompiledInitializationBuilder WithField(string fieldName, float value)
        {
            var field = new CompiledFieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new NumberLiteral(value));

            return this;
        }

        private CompiledInitializationBuilder WithLiteral(LiteralValue literalValue)
        {
            this.LiteralValue = literalValue;

            return this;
        }
    }
}
