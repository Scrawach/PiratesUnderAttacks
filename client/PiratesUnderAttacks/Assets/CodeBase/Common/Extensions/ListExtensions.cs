using System.Collections.Generic;

namespace CodeBase.Common.Extensions
{
    public static class ListExtensions
    {
        public static List<TObject> AddTo<TObject>(this TObject self, List<TObject> objects)
        {
            objects.Add(self);
            return objects;
        }
    }
}