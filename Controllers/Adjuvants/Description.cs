using System;

using static System.AttributeTargets;

namespace MarvellousPoker.Controllers.Adjuvants
{
    [AttributeUsage(All, AllowMultiple = false)]
    public class DescriptionAttribute : Attribute
    {
        public string StringValue { get; protected internal init; }
        public long LongValue { get; protected internal init; }

        public DescriptionAttribute(string stringValue) => StringValue = stringValue;
        public DescriptionAttribute(long longValue) => LongValue = longValue;
    }
}
