using System.Collections.Generic;
using System.Text;
using TheToolsmiths.Ddl.Models.Build.Types;
using TheToolsmiths.Ddl.Models.Build.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Paths
{
    public static class PathHelpers
    {
        public static string ToQualifiedString(in bool isRooted, IReadOnlyList<IPathPart> pathParts)
        {
            if (pathParts.Count == 0)
            {
                return isRooted ? TypeConstants.TypeSeparator : string.Empty;
            }

            var stringBuilder = new StringBuilder();

            if (isRooted)
            {
                stringBuilder.Append(TypeConstants.TypeSeparator);
            }

            for (int i = 0; i < pathParts.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append(TypeConstants.TypeSeparator);
                }

                stringBuilder.Append(pathParts[i].Name);
            }

            return stringBuilder.ToString();
        }

        public static string ToQualifiedString(in bool isRooted, IReadOnlyList<string> pathParts)
        {
            if (pathParts.Count == 0)
            {
                return isRooted ? TypeConstants.TypeSeparator : string.Empty;
            }

            var stringBuilder = new StringBuilder();

            if (isRooted)
            {
                stringBuilder.Append(TypeConstants.TypeSeparator);
            }

            for (int i = 0; i < pathParts.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append(TypeConstants.TypeSeparator);
                }

                stringBuilder.Append(pathParts[i]);
            }

            return stringBuilder.ToString();
        }

        public static string ToGenericName(string name, IReadOnlyList<GenericTypeNameParameter> genericParameters)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(name);
            stringBuilder.Append(TypeConstants.TypeParameterListBegin);

            for (int i = 0; i < genericParameters.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append(TypeConstants.TypeParameterSpacedSeparator);
                }

                stringBuilder.Append(genericParameters[i].Text);
            }

            stringBuilder.Append(TypeConstants.TypeParameterListEnd);

            return stringBuilder.ToString();
        }

        public static string ToGenericIdentifier(string name, in int genericParametersCount)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(name);
            stringBuilder.Append(TypeConstants.TypeParameterListBegin);

            for (int i = 0; i < genericParametersCount - 1; i++)
            {
                stringBuilder.Append(TypeConstants.TypeParameterSeparator);
            }

            stringBuilder.Append(TypeConstants.TypeParameterListEnd);

            return stringBuilder.ToString();
        }
    }
}
