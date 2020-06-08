namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class FieldValueInitialization
    {
        public FieldValueInitialization(
            string name,
            ValueInitialization initialization)
        {
            this.Name = name;
            this.Initialization = initialization;
        }

        public string Name { get; }

        public ValueInitialization Initialization { get; }
    }
}
