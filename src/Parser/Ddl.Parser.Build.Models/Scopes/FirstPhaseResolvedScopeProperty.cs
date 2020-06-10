namespace TheToolsmiths.Ddl.Parser.Build.Models.Scopes
{
    public abstract class FirstPhaseResolvedScopeProperty
    {
        protected FirstPhaseResolvedScopeProperty(FirstPhaseResolvedScopePropertyKind propertyKind, string name)
        {
            this.PropertyKind = propertyKind;
            this.Name = name;
        }

        public FirstPhaseResolvedScopePropertyKind PropertyKind { get; }

        public string Name { get; }
    }
}
