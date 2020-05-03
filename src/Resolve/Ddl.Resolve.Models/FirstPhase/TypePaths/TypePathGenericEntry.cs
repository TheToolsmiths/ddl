using System;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace Ddl.Resolve.Models.FirstPhase.TypePaths
{
    public class TypePathGenericEntry : TypePathEntry
    {
        public TypePathGenericEntry(Identifier identifier, int genericParametersCount)
            : base(TypePathEntryKind.Generic)
        {
            if (genericParametersCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(genericParametersCount));
            }

            this.Identifier = identifier;
            this.GenericParametersCount = genericParametersCount;
        }

        public Identifier Identifier { get; }

        public int GenericParametersCount { get; }

        public override string ToString()
        {
            return $"{this.Identifier}<{new string(',', this.GenericParametersCount)}>";
        }
    }
}
