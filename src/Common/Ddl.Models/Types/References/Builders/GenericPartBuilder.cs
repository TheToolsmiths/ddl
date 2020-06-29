using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Types.References.Builders
{
    public class GenericPartBuilder : TypeReferencePartBuilder
    {
        private readonly TypeReferenceBuilder.Context context;

        internal GenericPartBuilder(string name, TypeReferenceBuilder.Context context)
            : base(name)
        {
            this.context = context;
        }

        public List<TypeReferenceBuilder> ParameterTypes { get; } = new List<TypeReferenceBuilder>();

        public TypeReferenceBuilder AddGenericParameter()
        {
            TypeReferenceBuilder foo = new TypeReferenceBuilder(this.context);

            this.ParameterTypes.Add(foo);

            return foo;
        }

        public override TypeReferencePathPart Build()
        {
            var parameterTypesIndices = new List<int>();

            foreach (var parameterBuilder in this.ParameterTypes)
            {
                var type = parameterBuilder.Build();

                parameterTypesIndices.Add(this.context.BuiltReferences.Count);

                this.context.BuiltReferences.Add(type);
            }

            int parametersCount = this.ParameterTypes.Count;

            return new GenericReferencePathPart(this.Name, parametersCount, parameterTypesIndices);
        }
    }
}
