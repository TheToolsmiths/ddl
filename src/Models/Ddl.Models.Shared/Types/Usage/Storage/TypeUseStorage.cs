namespace TheToolsmiths.Ddl.Models.Types.Usage.Storage
{
    public abstract class TypeUseStorage
    {
        protected TypeUseStorage(TypeStorageUseKind storageKind)
        {
            this.StorageKind = storageKind;
        }

        public TypeStorageUseKind StorageKind { get; }

        public static TypeUseStorage SingleItem { get; } = new SingleItemTypeUseStorage();

        public static ArrayTypeUseStorage DynamicSized { get; } = ArrayTypeUseStorage.CreateFromSizes(new DynamicArraySize());
    }
}
