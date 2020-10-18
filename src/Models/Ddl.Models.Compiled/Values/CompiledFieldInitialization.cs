namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class CompiledFieldInitialization
    {
        public CompiledFieldInitialization(
            string name,
            CompiledValueInitialization initialization)
        {
            this.Name = name;
            this.Initialization = initialization;
        }

        public string Name { get; }

        public CompiledValueInitialization Initialization { get; }
    }
}
