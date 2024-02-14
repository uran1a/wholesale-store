using System.Globalization;
using System.Text.Json;

namespace WholesaleStore.Common.Extensions;

public static class StringExtension
{
    public static bool IsNullOrEmpty(this string data)
    {
        return string.IsNullOrEmpty(data);
    }

    public static bool IsNullOrWhiteSpace(this string data)
    {
        return string.IsNullOrWhiteSpace(data);
    }

    public static string ToTitleCase(this string text)
    {
        if (text == null)
            return null;

        var textInfo = new CultureInfo("en-US", false).TextInfo;
        text = textInfo.ToTitleCase(text.ToLower());
        return text;
    }

    public static string ToCamelCase(this string str)
    {
        return JsonNamingPolicy.CamelCase.ConvertName(str);
    }
}
