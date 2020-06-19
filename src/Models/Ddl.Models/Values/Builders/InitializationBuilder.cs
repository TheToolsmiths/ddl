using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types.References;

namespace TheToolsmiths.Ddl.Models.Values.Builders
{
    public class InitializationBuilder
    {
        private InitializationBuilder(ValueInitializationType initializationType)
        {
            this.InitializationType = initializationType;
            this.Fields = new List<FieldInitializationBuilder>();
            this.LiteralValue = new DefaultLiteral();
        }

        public ValueInitializationType InitializationType { get; set; }

        private List<FieldInitializationBuilder> Fields { get; }

        public LiteralValue LiteralValue { get; set; }

        public TypeReference? TypeReference { get; set; }

        public static InitializationBuilder StartStructured()
        {
            return new InitializationBuilder(ValueInitializationType.Struct);
        }

        public static InitializationBuilder StartLiteral()
        {
            return new InitializationBuilder(ValueInitializationType.Literal);
        }

        public EmptyInitialization BuildEmpty()
        {
            if (this.InitializationType != ValueInitializationType.Empty)
            {
                throw new NotImplementedException();
            }

            return new EmptyInitialization();
        }

        public LiteralInitialization BuildLiteral()
        {
            if (this.InitializationType != ValueInitializationType.Literal)
            {
                throw new NotImplementedException();
            }

            return new LiteralInitialization(this.LiteralValue);
        }

        public StructInitialization BuildStructured()
        {
            if (this.InitializationType != ValueInitializationType.Struct)
            {
                throw new NotImplementedException();
            }

            var fields = this.Fields.Select(f => f.Build()).ToList();

            return new StructInitialization(fields);
        }

        public TypedStructInitialization BuildTypeIdentifier()
        {
            if (this.InitializationType != ValueInitializationType.TypedStruct)
            {
                throw new NotImplementedException();
            }

            var fields = this.Fields.Select(f => f.Build()).ToList();

            TypeReference typeReference = this.TypeReference ?? throw new NotImplementedException();

            var initialization = new StructInitialization(fields);

            return new TypedStructInitialization(typeReference, initialization);
        }

        public ValueInitialization Build()
        {
            return this.InitializationType switch
            {
                ValueInitializationType.Empty => this.BuildEmpty(),
                ValueInitializationType.Literal => this.BuildLiteral(),
                ValueInitializationType.Struct => this.BuildStructured(),
                ValueInitializationType.TypedStruct => this.BuildTypeIdentifier(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public InitializationBuilder WithStructuredField(string fieldName)
        {
            var field = new FieldInitializationBuilder(fieldName, StartStructured());

            this.Fields.Add(field);

            return field.InitializationBuilder;
        }

        public InitializationBuilder WithField(string fieldName, bool value)
        {
            var field = new FieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new BoolLiteral(value));

            return this;
        }

        public InitializationBuilder WithField(string fieldName, int value)
        {
            var field = new FieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new NumberLiteral(value));

            return this;
        }

        public InitializationBuilder WithField(string fieldName, string value)
        {
            var field = new FieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new StringLiteral(value));

            return this;
        }

        public InitializationBuilder WithField(string fieldName, float value)
        {
            var field = new FieldInitializationBuilder(fieldName, StartLiteral());

            this.Fields.Add(field);

            field.InitializationBuilder.WithLiteral(new NumberLiteral(value));

            return this;
        }

        private InitializationBuilder WithLiteral(LiteralValue literalValue)
        {
            this.LiteralValue = literalValue;

            return this;
        }
    }
}
