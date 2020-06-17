using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.BuilderMaps
{
    internal class BuilderMapRegistry : IBuilderMapRegistry
    {
        private readonly IReadOnlyDictionary<Type, Type> itemBuilderMap;
        private readonly IReadOnlyDictionary<Type, Type> scopeBuilderMap;

        public BuilderMapRegistry(
            IReadOnlyDictionary<Type, Type> itemBuilderMap,
            IReadOnlyDictionary<Type, Type> scopeBuilderMap)
        {
            this.itemBuilderMap = itemBuilderMap;
            this.scopeBuilderMap = scopeBuilderMap;
        }

        public bool TryGetItemBuilderType(Type key, [MaybeNullWhen(returnValue: false)] out Type type)
        {
            return this.itemBuilderMap.TryGetValue(key, out type);
        }

        public bool TryGetScopeBuilderType(Type key, [MaybeNullWhen(returnValue: false)] out Type type)
        {
            return this.scopeBuilderMap.TryGetValue(key, out type);
        }
    }
}
