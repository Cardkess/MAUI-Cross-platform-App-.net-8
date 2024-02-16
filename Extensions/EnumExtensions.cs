using MAUI.Attributes;

namespace MAUI.Extensions;


public static class EnumExtensions<TEnum> where TEnum : Enum
{
    public static string? GetStringValue(TEnum value)
    {
        var type = typeof(TEnum);
        var fieldInfo = type.GetField(value.ToString());

        if (fieldInfo != null)
        {
            var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Value;
            }
        }

        return null; // Handle the case where no attribute is found or fieldInfo is null.
    }
}
