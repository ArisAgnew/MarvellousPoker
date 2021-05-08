using System.Collections.Generic;
using System.Linq;

namespace MarvellousPoker.Controllers.Adjuvants
{
    internal static class CollectionExtentions
    {
        internal static ICollection<T> OughtToBeEmpty<T>(this ICollection<T> collection)
            where T : notnull
        {
            if (collection.Any() && collection is not null)
            {
                collection.Clear();
            }
            return collection;
        }
    }
}
