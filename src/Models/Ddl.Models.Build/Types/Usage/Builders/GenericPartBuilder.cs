using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Types.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Usage.Builders
{
    public class GenericPartBuilder : TypeReferencePartBuilder
    {
        internal GenericPartBuilder(string name)
            : base(name)
        {
        }

        public List<TypeReferenceBuilder> ParameterTypes { get; } = new List<TypeReferenceBuilder>();

        public TypeReferenceBuilder AddGenericParameter()
        {
            TypeReferenceBuilder builder = new TypeReferenceBuilder();

            this.ParameterTypes.Add(builder);

            return builder;
        }

        public override TypePathPart Build()
        {
            var parameterTypes = new List<TypeUse>();

            foreach (var parameterBuilder in this.ParameterTypes)
            {
                var typeUse = parameterBuilder.Build();

                parameterTypes.Add(typeUse);
            }

            return new GenericPathPart(this.Name, parameterTypes);
        }
    }
}
