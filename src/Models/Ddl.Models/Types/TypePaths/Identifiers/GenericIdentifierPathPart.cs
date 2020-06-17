namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers
{
    public class GenericIdentifierPathPart : TypeIdentifierPathPart
    {
        public GenericIdentifierPathPart(
            string name,
            int genericParametersCount)
            : base(name)
        {
            this.GenericParametersCount = genericParametersCount;
        }

        public override TypeIdentifierPathPartKind PartKind => TypeIdentifierPathPartKind.Generic;

        public int GenericParametersCount { get; }

        public override string ToString()
        {
            return $"{this.Name}<{new string(c: ',', this.GenericParametersCount - 1)}>";
        }
    }
}
