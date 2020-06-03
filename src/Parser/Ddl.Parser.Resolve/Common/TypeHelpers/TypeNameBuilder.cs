using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

using TypeName = TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names.TypeName;

namespace TheToolsmiths.Ddl.Resolve.Common.TypeHelpers
{
    public static class TypeNameBuilder
    {
        public static ItemTypeName CreateItemTypeName(TypeName typeName)
        {
            TypeNameIdentifier itemNameIdentifier = typeName switch
            {
                GenericTypeName genericType => CreateGenericTypeName(genericType),
                SimpleTypeName simpleType => new SimpleTypeNameIdentifier(simpleType.Name.Text),
                _ => throw new ArgumentOutOfRangeException(nameof(typeName))
            };

            return new ItemTypeName(itemNameIdentifier);

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

        public static SubItemTypeName CreateSubItemTypeName(ItemTypeName itemTypeName, Identifier subItemIdentifier)
        {
            var subItemTypeName = new SimpleTypeNameIdentifier(subItemIdentifier.Text);

            return new SubItemTypeName(itemTypeName.ItemNameIdentifier, subItemTypeName);
        }
    }
}
