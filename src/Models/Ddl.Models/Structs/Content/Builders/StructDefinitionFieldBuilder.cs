using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
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

        public List<AttributeUseBuilder> Attributes { get; } = new List<AttributeUseBuilder>();

        public TypeReferenceBuilder WithType()
        {
            return this.TypeBuilder;
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

            var fieldType = this.TypeBuilder;

            var attributes = this.Attributes.Select(a => a.Build()).ToList();

            var initialization = ValueInitialization.CreateEmpty();

            return new FieldDefinition(this.Name, fieldType, attributes, initialization);
        }

        public AttributeUseBuilder AddTypedAttribute(string attributeType)
        {
            var builder = AttributeUseBuilder.CreateTyped(attributeType);

            this.Attributes.Add(builder);

            return builder;
        }

        public AttributeUseBuilder AddConditionalAttribute(string attributeType, ConditionalExpression expression)
        {
            var builder = AttributeUseBuilder.CreateConditional(attributeType, expression);

            this.Attributes.Add(builder);

            return builder;
        }
    }
}
