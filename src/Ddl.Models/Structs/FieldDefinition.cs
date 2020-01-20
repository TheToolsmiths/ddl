﻿using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class FieldDefinition : IStructDefinitionItem
    {
        public FieldDefinition(
            FieldName name,
            TypeIdentifier fieldType,
            ValueInitialization initialization,
            IReadOnlyList<IAttributeUse> attributes)
        {
            this.Attributes = attributes;
            this.Initialization = initialization;
            this.FieldType = fieldType;
            this.Name = name;
        }

        public FieldName Name { get; }

        public TypeIdentifier FieldType { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.FieldDefinition;
    }
}