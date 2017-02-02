using System.Collections.Generic;

namespace GoogleHashCode_StreetViewRouting.Extensions
{
    public static class ListExtension
    {
        public static List<T> CloneAndAdd<T>(this List<T> list, T item)
        {
            List<T> copy = new List<T>(list);
            copy.Add(item);
            return copy;
        }
    }
}