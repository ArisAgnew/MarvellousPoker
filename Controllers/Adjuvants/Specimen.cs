using static System.AttributeTargets;

namespace MarvellousPoker.Controllers.Adjuvants
{
    [AttributeUsage(Field, AllowMultiple = false)]
    public class SpecimenAttribute : Attribute
    {
        public long LongValue { get; init; }

        public string StringValue { get; init; }

        public ICollection<string> StringList { get; init; }

        public SpecimenAttribute(params string[] stringList) => StringList = stringList;
    }
}
