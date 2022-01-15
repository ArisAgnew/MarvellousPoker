namespace MarvellousPoker.Controllers.Adjuvants
{
    internal static class AttributeFunctioning
    {
        [return: NotNullIfNotNull("@object")]
        public static (string? StringValue, long? NumberValue) GetDescriptionValue(this object? @object)
        {
            DescriptionAttribute[]? attrs = default;
            try
            {
                FieldInfo? fieldInfo = @object?.GetType().GetField(@object.ToString());
                attrs = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            }
            catch (Exception e)
            {
                WriteLine($"\tSomething went wrong: {e.Message}\n{e.StackTrace}");
            }

            //TODO 01/15/2022: some defect pushed his way through the NumberValue extracting
            return attrs?.Length > 0
                ? (attrs[0].StringValue, attrs[0].NumberValue)
                : (default, default);
        }
    }
}
