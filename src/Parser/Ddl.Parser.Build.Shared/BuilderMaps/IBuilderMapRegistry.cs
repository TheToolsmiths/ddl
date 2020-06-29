using System;
using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Parser.Build.BuilderMaps
{
    public interface IBuilderMapRegistry
    {
        bool TryGetItemBuilderType(Type key, [MaybeNullWhen(false)] out Type type);

        bool TryGetScopeBuilderType(Type key, [MaybeNullWhen(false)] out Type type);
    }
}
