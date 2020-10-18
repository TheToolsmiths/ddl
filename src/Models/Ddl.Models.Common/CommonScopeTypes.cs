using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models
{
    public static class CommonScopeTypes
    {
        public static ScopeType ConditionalScope { get; } = new ScopeType("scope/conditional");

        public static ScopeType RootScope { get; } = new ScopeType("scope/root");
    }
}
