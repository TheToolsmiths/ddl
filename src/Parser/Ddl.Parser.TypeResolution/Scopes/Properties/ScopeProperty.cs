namespace TheToolsmiths.Ddl.TypeResolution.Scopes.Properties
{
    public abstract class ScopeProperty
    {
        protected ScopeProperty(ScopePropertyKind propertyKind, string name)
        {
            this.PropertyKind = propertyKind;
            this.Name = name;
        }

        public ScopePropertyKind PropertyKind { get; }

        public string Name { get; }
    }
}
