﻿using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.Scopes
{
    public abstract class RootScopeBase : IRootScope
    {
        protected RootScopeBase(ScopeContent content)
        {
            this.Content = content;
        }

        public ScopeContent Content { get; }

        public abstract ScopeType ScopeType { get; }
    }
}