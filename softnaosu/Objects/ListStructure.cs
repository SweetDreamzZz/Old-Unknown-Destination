using System.Collections.Generic;

namespace softnaosu.Objects
{
    public class ListStructure<T> : StructureBase
    {
        public readonly List<T> ListItems = new();

        public int ListSize;
    }
}