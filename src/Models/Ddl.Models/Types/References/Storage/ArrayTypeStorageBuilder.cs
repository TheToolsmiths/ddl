﻿using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Types.References.Storage
{
    public class ArrayTypeStorageBuilder
    {
        private readonly List<ArraySize> arraySizes = new List<ArraySize>();

        public static ArrayTypeStorageBuilder WithDynamicSize()
        {
            return new ArrayTypeStorageBuilder().AddDynamicSize();
        }

        private ArrayTypeStorageBuilder AddDynamicSize()
        {
            this.arraySizes.Add(new DynamicArraySize());

            return this;
        }

        public ArrayTypeStorageBuilder AddFixedSize(int size)
        {
            this.arraySizes.Add(new FixedArraySize(size));

            return this;
        }

        public ArrayTypeStorageBuilder AddFixedSizes(params int[] sizes)
        {
            this.arraySizes.Add(new FixedArraySize(sizes));

            return this;
        }

        public static implicit operator ArrayTypeStorage(ArrayTypeStorageBuilder builder)
        {
            return builder.Build();
        }

        private ArrayTypeStorage Build()
        {
            return ArrayTypeStorage.CreateFromSizes(this.arraySizes);
        }
    }
}
