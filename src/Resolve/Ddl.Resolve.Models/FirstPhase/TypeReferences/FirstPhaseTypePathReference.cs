using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase.TypeReferences
{
    public abstract class FirstPhaseTypePathReference
    {
        protected FirstPhaseTypePathReference(FirstPhaseTypeName typeName)
        {
            this.TypeName = typeName;
        }

        public FirstPhaseTypeName TypeName { get; }
    }
}
