namespace TheToolsmiths.Ddl.Models
{
    public class FieldValueInitialization
    {
        public FieldValueInitialization(
            FieldName name,
            ValueInitialization initialization)
        {
            Name = name;
            Initialization = initialization;
        }

        public FieldName Name { get; }

        public ValueInitialization Initialization { get; }
    }
}
