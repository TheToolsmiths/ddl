using System;
using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Types.References
{
    public class SubItemTypePathReference : EntityTypeReference
    {
        public SubItemTypePathReference(
            SubItemTypeName typeName,
            RootNamespacePath namespacePath,
            SubItemReference subItemReference)
            : base(namespacePath)
        {
            this.TypeName = typeName;
            this.SubItemReference = subItemReference;
        }

        public SubItemReference SubItemReference { get; }

        public SubItemTypeName TypeName { get; }

        public override EntityReference EntityReference => this.SubItemReference;

        public override TypeName EntityTypeName => this.TypeName;

        public override string ToString()
        {
            throw new NotImplementedException();

            //return $"{this.SubItemReference} > {this.TypeIdentifier}";
        }
    }
}
