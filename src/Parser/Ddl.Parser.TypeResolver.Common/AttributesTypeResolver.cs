using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Common
{
    public class AttributesTypeResolver
    {
        public Result<AttributeUseCollection> ResolveAttributes(IRootScopeTypeResolveContext context, AttributeUseCollection attributes)
        {
            var resolvedAttributes = new List<IAttributeUse>();

            foreach (var attribute in attributes.Items)
            {
                var result = this.ResolveAttribute(context, attribute);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                resolvedAttributes.Add(result.Value);
            }
            
            return Result.FromValue(AttributeUseCollection.Create(resolvedAttributes));
        }

        private Result<IAttributeUse> ResolveAttribute(IRootScopeTypeResolveContext context, IAttributeUse attribute)
        {
            return attribute switch
            {
                ConditionalAttributeUse _ => this.PassthroughResolve(context, attribute),
                KeyedLiteralAttributeUse _ => this.PassthroughResolve(context, attribute),
                KeyedStructInitializationAttributeUse _ => this.PassthroughResolve(context, attribute),
                KeyedTypedAttributeUse keyedTyped => this.ResolveKeyedTypedAttribute(context, keyedTyped),
                TypedStructInitializationUse typedStructInitialization => this.ResolveTypedStructInitializationAttribute(context, typedStructInitialization),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute))
            };
        }

        private Result<IAttributeUse> ResolveTypedStructInitializationAttribute(IRootScopeTypeResolveContext context, TypedStructInitializationUse typedAttribute)
        {
            var resolvedType = context.TypeReferenceResolver.Resolve(typedAttribute.Type);

            var resolvedAttribute = new TypedStructInitializationUse(resolvedType, typedAttribute.Initialization);

            return Result.FromValue<IAttributeUse>(resolvedAttribute);
        }

        private Result<IAttributeUse> ResolveKeyedTypedAttribute(IRootScopeTypeResolveContext context, KeyedTypedAttributeUse keyedTypedAttribute)
        {
            var resolvedType = context.TypeReferenceResolver.Resolve(keyedTypedAttribute.Type);

            var resolvedAttribute = new KeyedTypedAttributeUse(keyedTypedAttribute.Key, resolvedType, keyedTypedAttribute.Initialization);

            return Result.FromValue<IAttributeUse>(resolvedAttribute);
        }

        private Result<IAttributeUse> PassthroughResolve(IRootScopeTypeResolveContext _, IAttributeUse attribute)
        {
            return Result.FromValue(attribute);
        }
    }
}
