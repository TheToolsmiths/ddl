﻿namespace TheToolsmiths.Ddl.Models.EntryTypes
{
    public static class CommonScopeTypes
    {
        public static ScopeType ConditionalScope { get; } = new ScopeType("scope/conditional");

        public static ScopeType RootScope { get; } = new ScopeType("scope/root");
    }
}
