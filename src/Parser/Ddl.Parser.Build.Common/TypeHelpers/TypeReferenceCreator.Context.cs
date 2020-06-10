using System;
using System.Collections.Generic;
using System.Diagnostics;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers
{
    public static partial class TypeReferenceCreator
    {
        [DebuggerDisplay("{Builder.TypePath}")]
        private class TypeIdentifierBuildContext
        {
            private readonly List<TypeIdentifierBuildContext> typesToResolve;
            private readonly List<int> usedTypesIndices = new List<int>();

            public TypeIdentifierBuildContext(
                List<TypeIdentifierBuildContext> typesToResolve,
                ITypeIdentifier typeIdentifier)
            {
                this.TypeIdentifier = typeIdentifier;
                this.Builder = new TypeReferenceBuilder();
                this.typesToResolve = typesToResolve;
            }

            public ITypeIdentifier TypeIdentifier { get; }

            public TypeReferenceBuilder Builder { get; }

            public IReadOnlyList<int> UsedTypesIndices => this.usedTypesIndices;

            public int EnqueueTypeIdentifier(IGenericParameterTypeIdentifier typeIdentifier)
            {
                var context = new TypeIdentifierBuildContext(this.typesToResolve, typeIdentifier);

                this.typesToResolve.Add(context);

                return this.typesToResolve.Count - 1;
            }

            public void SetUsedTypeIndices(IReadOnlyList<int> typesIndices)
            {
                if (this.usedTypesIndices.Count > 0)
                {
                    throw new ArgumentException(nameof(typesIndices));
                }

                this.usedTypesIndices.AddRange(typesIndices);
            }
        }
    }
}
