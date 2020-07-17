using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Types.References.Builders;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.Structs.Content.Builders
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

        public FieldDefinition Build()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                throw new InvalidOperationException();
            }

            var fieldType = this.TypeReference ?? this.TypeBuilder;

            var attributes = this.AttributeBuilders.Select(a => a.Build()).ToList();
            attributes.AddRange(this.Attributes);

            var initialization = ValueInitialization.CreateEmpty();

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
