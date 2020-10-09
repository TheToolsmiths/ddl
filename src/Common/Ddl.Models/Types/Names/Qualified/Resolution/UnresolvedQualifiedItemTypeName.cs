﻿namespace TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution
{
    public class UnresolvedQualifiedItemTypeName : QualifiedItemTypeNameResolution
    {
        public UnresolvedQualifiedItemTypeName()
            : base(QualifiedTypeNameResolutionKind.Unresolved)
        {
        }

        public override string ToString()
        {
            return "Unresolved Item TypeName";
        }
    }
}
