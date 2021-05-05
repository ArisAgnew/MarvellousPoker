using System;

using static System.Int32;

namespace MarvellousPoker.Controllers.Adjuvants
{
    public static class HashExtentions
    {
        private static readonly int baseValue = new Random().Next(MinValue, MaxValue) >> 5;

        public static int GetHashCode<T>(this T arg)
            where T : notnull
            => unchecked(baseValue + arg.GetHashCode());

        public static int GetHashCode<T1, T2>(this T1 arg1, T2 arg2)
            where T1 : notnull where T2 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>());

        public static int GetHashCode<T1, T2, T3>(this T1 arg1, T2 arg2, T3 arg3)
            where T1 : notnull where T2 : notnull where T3 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>() +
                arg3.GetHashCode<T3>());

        public static int GetHashCode<T1, T2, T3, T4>(this T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>() +
                arg3.GetHashCode<T3>() +
                arg4.GetHashCode<T4>());

        public static int GetHashCode<T1, T2, T3, T4, T5>(this T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
            => unchecked(arg1.GetHashCode<T1>() +
                arg2.GetHashCode<T2>() +
                arg3.GetHashCode<T3>() +
                arg4.GetHashCode<T4>() +
                arg5.GetHashCode<T5>());
    }
}
