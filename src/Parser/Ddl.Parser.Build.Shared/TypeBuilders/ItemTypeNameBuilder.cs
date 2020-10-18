using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Ast.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Models.Types.Names;

using TypeName = TheToolsmiths.Ddl.Models.Ast.Types.Names.TypeName;

namespace TheToolsmiths.Ddl.Parser.Build.TypeBuilders
{
    public static class ItemTypeNameBuilder
    {
        public static ItemTypeName CreateItemTypeName(TypeName typeName)
        {
            TypeNameIdentifier itemTypeName = typeName switch
            {
                GenericTypeName genericType => CreateGenericTypeName(genericType),
                SimpleTypeName simpleType => new SimpleTypeNameIdentifier(simpleType.Name.Text),
                _ => throw new ArgumentOutOfRangeException(nameof(typeName))
            };

            return new ItemTypeName(itemTypeName);

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
    }
}
