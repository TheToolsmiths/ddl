﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Configurations.Ast
{
    public class AstConfigurationSection : IAstConfigurationSection
    {
        private readonly IReadOnlyDictionary<AstItemType, Type> itemBuilders;
        private readonly IReadOnlyDictionary<AstScopeType, Type> scopeBuilders;

        public AstConfigurationSection(
            IReadOnlyDictionary<AstItemType, Type> itemBuilders,
            IReadOnlyDictionary<AstScopeType, Type> scopeBuilders)
        {
            this.itemBuilders = itemBuilders;
            this.scopeBuilders = scopeBuilders;
        }

        public bool TryGetTypeValue(AstItemType itemType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.itemBuilders.TryGetValue(itemType, out typeValue);
        }

        public bool TryGetTypeValue(AstScopeType scopeType, [NotNullWhen(true)] out Type? typeValue)
        {
            return this.scopeBuilders.TryGetValue(scopeType, out typeValue);
        }
    }
}