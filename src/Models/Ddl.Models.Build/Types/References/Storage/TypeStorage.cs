namespace TheToolsmiths.Ddl.Models.Build.Types.References.Storage
{
    public abstract class TypeStorage
    {
        protected TypeStorage(TypeStorageKind storageKind)
        {
            this.StorageKind = storageKind;
        }

        public TypeStorageKind StorageKind { get; }

        public static TypeStorage SingleItem { get; } = new SingleItemTypeStorage();

        public static ArrayTypeStorage DynamicSized { get; } = ArrayTypeStorage.CreateFromSizes(new DynamicArraySize());
    }
}
