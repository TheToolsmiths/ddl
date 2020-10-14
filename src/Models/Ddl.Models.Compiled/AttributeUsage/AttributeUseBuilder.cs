using TheToolsmiths.Ddl.Models.Compiled.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Compiled.Types.References.Builders;
using TheToolsmiths.Ddl.Models.Compiled.Values.Builders;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class AttributeUseBuilder
    {
        public TypeReferenceBuilder TypeBuilder { get; } = TypeReferenceBuilder.Start();

        public InitializationBuilder StructuredInitialization { get; } = InitializationBuilder.StartStructured();

        public ConditionalExpression ConditionalExpression { get; set; } = ConditionalExpression.Empty;

        public bool IsConditional { get; set; }

        public bool IsTyped { get; set; }

        public IAttributeUse Build()
        {
            if (this.IsTyped)
            {
                return CreateTypedStructInitialization();
            }

            if (this.IsConditional)
            {
                return CreateConditional();
            }

            throw new System.NotImplementedException();

            TypedStructInitializationUse CreateTypedStructInitialization()
            {
                var type = this.TypeBuilder.Build();
                var initialization = this.StructuredInitialization.BuildStructured();

                return new TypedStructInitializationUse(type, initialization);
            }

            ConditionalAttributeUse CreateConditional()
            {
                var type = this.TypeBuilder.Build();

                return new ConditionalAttributeUse(type, this.ConditionalExpression);
            }
        }

        public static AttributeUseBuilder CreateTyped(string attributeType)
        {
            var builder = new AttributeUseBuilder { IsTyped = true };

            builder.TypeBuilder.StartsWithSimplePath(attributeType);

            return builder;
        }

        public static AttributeUseBuilder CreateConditional(string attributeType, ConditionalExpression expression)
        {
            var builder = new AttributeUseBuilder { IsConditional = true };

            builder.TypeBuilder.StartsWithSimplePath(attributeType);

            builder.ConditionalExpression = expression;

            return builder;
        }

        public TypeReferenceBuilder WithType()
        {
            return this.TypeBuilder;
        }

        public InitializationBuilder WithStructuredInitialization()
        {
            return this.StructuredInitialization;
        }
    }
}
