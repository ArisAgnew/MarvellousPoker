using System;
using System.Collections.Generic;
using System.Linq;

using static System.ConsoleColor;

namespace MarvellousPoker.Controllers.Adjuvants
{
    internal static class CollectionExtentions
    {
        internal static IEnumerable<T> OughtToBeEmpty<T>(this ICollection<T> collection)
            where T : notnull
        {
            if (collection.Any() && collection is not null)
            {
                try
                {
                    collection.Clear();
                }
                catch (Exception e) when (e is NotSupportedException)
                {
                    ($"An error occurred while making a collection empty.\n" +
                    $"\tCause: {e.Message}.\n" +
                    $"\tTargetSite: {e.TargetSite}\n").Depict(Red);
                }
            }
            return collection;
        }
    }
}
