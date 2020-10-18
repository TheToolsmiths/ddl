using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Build.Types.Usage.Builders;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders
{
    public class FieldBuilder
    {
        public FieldBuilder(string name)
        {
            this.Name = name;
            this.TypeBuilder = TypeReferenceBuilder.Start();
        }

        public string Name { get; set; }

        public TypeReferenceBuilder TypeBuilder { get; }

        public TypeUse? TypeReference { get; set; }

        public List<AttributeUseBuilder> AttributeBuilders { get; } = new List<AttributeUseBuilder>();

        public List<IAttributeUse> Attributes { get; } = new List<IAttributeUse>();

        public ValueInitialization Initialization { get; set; } = ValueInitialization.CreateEmpty();

        public AttributeUseCollection? AttributeCollection { get; set; }

        public TypeReferenceBuilder WithType()
        {
            return this.TypeBuilder;
        }

        public FieldBuilder WithType(TypeUse type)
        {
            this.TypeReference = type;

            return this;
        }

        public FieldBuilder WithName(string name)
        {
            this.Name = name;

            return this;
        }

        public FieldBuilder AddInitialization(ValueInitialization initialization)
        {
            this.Initialization = initialization;

            return this;
        }

        public Field Build()
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

            return new Field(this.Name, fieldType, attributes, initialization);
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
