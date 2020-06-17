namespace TheToolsmiths.Ddl.Models.Values
{
    public class FieldInitialization
    {
        public FieldInitialization(
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
