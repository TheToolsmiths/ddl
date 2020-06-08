namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
    public abstract class TypeStorage
    {
        protected TypeStorage(TypeStorageKind storageKind)
        {
            this.StorageKind = storageKind;
        }

        public TypeStorageKind StorageKind { get; }
    }
}
