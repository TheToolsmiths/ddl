﻿using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
{
    public interface IEnumStructDefinitionItem : ITypedContentSubItem
    {
        EnumStructDefinitionItemType ItemType { get; }
    }
}