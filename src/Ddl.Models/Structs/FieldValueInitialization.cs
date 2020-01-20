using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class FieldValueInitialization
    {
        public FieldValueInitialization(
            FieldName name,
            ValueInitialization initialization)
        {
            this.Name = name;
            this.Initialization = initialization;
        }

        public FieldName Name { get; }

        public ValueInitialization Initialization { get; }
    }
}
