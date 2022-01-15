namespace MarvellousPoker.Controllers.Adjuvants
{
    internal static class PotentialNullValueExtentions
    {
        private const string EXCEPTION_MESSAGE = "{0} has null value.";

        internal static T MightBeNullOrDefault<T>(this T adjacentType, string message = default) =>
            adjacentType switch
            {
                T when EqualityComparer<T>.Default.Equals(adjacentType, default) => default,
                null => throw new ArgumentNullException(Format(EXCEPTION_MESSAGE, message)),
                not null => adjacentType
            };

        internal static T MightBeNullOrDefault<T>(this T adjacentType,
                                                  Func<T, T> func,
                                                  string message) => func.MightBeNullOrDefault(message)(adjacentType);
    }
}
