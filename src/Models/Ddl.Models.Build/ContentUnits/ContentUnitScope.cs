﻿using TheToolsmiths.Ddl.Models.Build.Scopes;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits
{
    public class ContentUnitScope
    {
        public ContentUnitScope(ScopeContent content)
        {
            this.Content = content;
        }

        public ScopeContent Content { get; }
    }
}