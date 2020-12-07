using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models
{
    public static class CommonScopeTypes
    {
        public static ScopeType ConditionalScope { get; } = new("scope/conditional");

        public static ScopeType RootScope { get; } = new("scope/root");
    }
}
