using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Types.References.Resolve;
using TheToolsmiths.Ddl.Models.Build.Types.Resolution;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Models.Build.Types.References.Builders
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
            TypeReferenceBuilder builder = new TypeReferenceBuilder(this.context);

            this.ParameterTypes.Add(builder);

            return builder;
        }

        public override TypeReferencePathPart Build()
        {
            var parameterTypesIndices = new List<int>();

            foreach (var parameterBuilder in this.ParameterTypes)
            {
                var typeReference = parameterBuilder.Build();

                parameterTypesIndices.Add(typeReference.TypeResolve.TypeIndex);

                var typeResolveState = new ReferencedTypeResolveState(typeReference, TypeResolution.Unresolved);

                this.context.BuiltReferences.Add(typeResolveState);
            }

            int parametersCount = this.ParameterTypes.Count;

            return new GenericReferencePathPart(this.Name, parametersCount, parameterTypesIndices);
        }
    }
}
