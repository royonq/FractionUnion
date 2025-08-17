using System;

namespace Enums
{
    [Flags]
    public enum UnionTypes
    {
        Trade = 1 << 0, 
        Science = 1 << 1, 
        War = 1 << 2, 
    }
}