using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Models.Build.Types.References.Builders;
using TheToolsmiths.Ddl.Models.Build.Values;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders
{
    public class StructDefinitionFieldBuilder
    {
        public StructDefinitionFieldBuilder(string name)
        {
            this.Name = name;
            this.TypeBuilder = TypeReferenceBuilder.Start();
        }

        public string Name { get; set; }

        public TypeReferenceBuilder TypeBuilder { get; }

        public TypeReference? TypeReference { get; set; }

        public List<AttributeUseBuilder> AttributeBuilders { get; } = new List<AttributeUseBuilder>();

        public List<IAttributeUse> Attributes { get; } = new List<IAttributeUse>();

        public ValueInitialization Initialization { get; set; } = ValueInitialization.CreateEmpty();

        public AttributeUseCollection? AttributeCollection { get; set; }

        public TypeReferenceBuilder WithType()
        {
            return this.TypeBuilder;
        }

        public StructDefinitionFieldBuilder WithType(TypeReference type)
        {
            this.TypeReference = type;

            return this;
        }

        public StructDefinitionFieldBuilder WithName(string name)
        {
            this.Name = name;

            return this;
        }

        public StructDefinitionFieldBuilder AddInitialization(ValueInitialization initialization)
        {
            this.Initialization = initialization;

            return this;
        }

        public FieldDefinition Build()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new InvalidOperationException();
            }

            var fieldType = this.TypeReference ?? this.TypeBuilder.Build();

            var builtAttributes = this.AttributeBuilders.Select(a => a.Build()).ToList();
            builtAttributes.AddRange(this.Attributes);

            var attributes = this.AttributeCollection ?? AttributeUseCollection.Create(this.Attributes);

            var initialization = this.Initialization;

            return new FieldDefinition(this.Name, fieldType, attributes, initialization);
        }

        public AttributeUseBuilder AddTypedAttribute(string attributeType)
        {
            var builder = AttributeUseBuilder.CreateTyped(attributeType);

            this.AttributeBuilders.Add(builder);

            return builder;
        }

        public AttributeUseBuilder AddConditionalAttribute(string attributeType, ConditionalExpression expression)
        {
            var builder = AttributeUseBuilder.CreateConditional(attributeType, expression);

            this.AttributeBuilders.Add(builder);

            return builder;
        }
    }
}
