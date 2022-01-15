namespace MarvellousPoker.Controllers.Adjuvants
{
    public static class CacheExtentionsTrial
    {
        public static Func<T> TimeCache<T>(this Func<T> func, int cacheInterval)
        {
            var cachedValue = func();
            var timeCached = Now;

            return () =>
            {
                if ((Now - timeCached).Seconds >= cacheInterval)
                {
                    timeCached = Now;
                    cachedValue = func();
                }
                return cachedValue;
            };
        }
    }
}
