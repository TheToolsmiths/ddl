using System;

using TheToolsmiths.Ddl.Models.Compiled.Items.References;

using ItemReference = TheToolsmiths.Ddl.Models.Build.Items.References.ItemReference;
using SubItemReference = TheToolsmiths.Ddl.Models.Build.Items.References.SubItemReference;

namespace TheToolsmiths.Ddl.Parser.Compiler.Helpers
{
    internal static class EntityReferenceHelper
    {
        public static EntityReference CreateEntityReference(
            Models.Build.Items.References.EntityReference entityReference)
        {
            return entityReference switch
            {
                ItemReference itemReference => ToItemReference(itemReference),
                SubItemReference subItemReference => ToSubItemReference(subItemReference),
                _ => throw new ArgumentOutOfRangeException(nameof(entityReference))
            };
        }

        public static Models.Compiled.Items.References.ItemReference ToItemReference(ItemReference reference)
        {
            return new Models.Compiled.Items.References.ItemReference(reference.ItemId);
        }

        public static Models.Compiled.Items.References.SubItemReference ToSubItemReference(SubItemReference reference)
        {
            return new Models.Compiled.Items.References.SubItemReference(reference.ItemId, reference.SubItemId);
        }
    }
}
