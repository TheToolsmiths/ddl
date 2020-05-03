namespace Ddl.Resolve.Models.FirstPhase.TypePaths
{
    public abstract class TypePathEntry
    {
        protected TypePathEntry(TypePathEntryKind kind)
        {
            this.Kind = kind;
        }

        public TypePathEntryKind Kind { get; }

        public abstract string ToString();
    }
}
