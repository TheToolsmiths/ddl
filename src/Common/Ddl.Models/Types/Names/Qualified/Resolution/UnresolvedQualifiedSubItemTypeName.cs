﻿namespace TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution
{
    public class UnresolvedQualifiedSubItemTypeName : QualifiedSubItemTypeNameResolution
    {
        public UnresolvedQualifiedSubItemTypeName()
            : base(QualifiedTypeNameResolutionKind.Unresolved)
        {
        }

        public override string ToString()
        {
            return $"SubItem TypeName: {nameof(QualifiedTypeNameResolutionKind.Unresolved)}";
        }
    }
}
