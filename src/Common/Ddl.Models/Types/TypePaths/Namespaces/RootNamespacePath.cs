using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces
{
    public class RootNamespacePath : NamespacePath
    {
        private RootNamespacePath(IEnumerable<string> identifiers)
            : base(identifiers, true)
        {
        }

        private RootNamespacePath()
            : base(true)
        {
        }

        public static RootNamespacePath EmptyRoot { get; } = new RootNamespacePath();

        public new static RootNamespacePath CreateFromIdentifiers(IEnumerable<string> identifiers)
        {
            return new RootNamespacePath(identifiers);
        }
    }
}
