﻿using System;

namespace TheToolsmiths.Ddl.Parser.Build.BuilderMaps
{
    public class BuilderMapRegistry : IBuilderMapRegistry
    {
        public bool TryGetItemBuilderType(Type key, out Type type)
        {
            throw new NotImplementedException();
        }

        public bool TryGetScopeBuilderType(Type key, out Type type)
        {
            throw new NotImplementedException();
        }
    }
}