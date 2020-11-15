﻿using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Enums.Builders
{
    public class EnumStructDefinitionBuilder
    {
        public EnumStructDefinitionBuilder()
        {
            this.Variants = new List<EnumStructVariantBuilder>();
        }

        public SimpleTypeNameIdentifier? TypeName { get; set; }

        public List<EnumStructVariantBuilder> Variants { get; }

        public EnumStructDefinition Build()
        {
            var nameIdentifier = this.TypeName ?? throw new NotImplementedException();

            var typeName = new ItemTypeName(nameIdentifier);

            var variants = this.Variants.Select(v => v.Build()).ToList();

            throw new NotImplementedException();

            //var typeNameResolution = QualifiedItemTypeNameResolution.Unresolved;

            //return new EnumStructDefinition(typeName, typeNameResolution, variants, AttributeUseCollection.Empty);
        }

        public EnumStructDefinitionBuilder WithSimpleTypeName(string typeName)
        {
            this.TypeName = new SimpleTypeNameIdentifier(typeName);

            return this;
        }

        public EnumStructVariantBuilder WithVariant(string variantName)
        {
            EnumStructVariantBuilder variantBuilder = new EnumStructVariantBuilder(variantName);

            this.Variants.Add(variantBuilder);

            return variantBuilder;
        }
    }
}