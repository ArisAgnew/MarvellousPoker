using System;
using System.Collections.Generic;

using static System.String;

namespace MarvellousPoker.Controllers.Adjuvants
{
    internal static class NullValueExtentions
    {
        private static readonly string EXCEPTION_MESSAGE = "{0} has null value.";

        internal static T MightBeNullOrDefault<T>(this T adjacentType, string message = default) =>
            adjacentType switch
            {
                T when EqualityComparer<T>.Default.Equals(adjacentType, default) => default,
                null => throw new NullReferenceException(Format(EXCEPTION_MESSAGE, message)),
                not null => adjacentType
            };
    }
}
