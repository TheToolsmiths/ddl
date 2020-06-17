using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;
using TypeName = TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names.TypeName;

namespace TheToolsmiths.Ddl.Parser.Build.Common.TypeHelpers
{
    public static class TypeNameBuilder
    {
        public static TypedItemName CreateItemTypeName(TypeName typeName)
        {
            TypeNameIdentifier itemNameIdentifier = typeName switch
            {
                GenericTypeName genericType => CreateGenericTypeName(genericType),
                SimpleTypeName simpleType => new SimpleTypeNameIdentifier(simpleType.Name.Text),
                _ => throw new ArgumentOutOfRangeException(nameof(typeName))
            };

            return new TypedItemName(itemNameIdentifier);

            TypeNameIdentifier CreateGenericTypeName(GenericTypeName genericType)
            {
                var genericParameters = new List<GenericTypeNameParameter>();

                foreach (var typeParameter in genericType.TypeParameters)
                {
                    var parameter = new GenericTypeNameParameter(typeParameter.Text);

                    genericParameters.Add(parameter);
                }

                return new GenericTypeNameIdentifier(typeName.Name.Text, genericParameters);
            }
        }

        public static TypedSubItemName CreateSubItemTypeName(TypedItemName typedItemName, Identifier subItemIdentifier)
        {
            var subItemTypeName = new SimpleTypeNameIdentifier(subItemIdentifier.Text);

            return new TypedSubItemName(typedItemName.ItemNameIdentifier, subItemTypeName);
        }
    }
}
