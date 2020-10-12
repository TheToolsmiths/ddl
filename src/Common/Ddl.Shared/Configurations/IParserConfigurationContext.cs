﻿using System.Diagnostics.CodeAnalysis;

namespace TheToolsmiths.Ddl.Configurations
{
    public interface IParserConfigurationContext
    {
        bool TryGetConfigurationBuilder<T>([NotNullWhen(true)] out T? builder)
            where T : class, IConfigurationBuilder;
    }
}
