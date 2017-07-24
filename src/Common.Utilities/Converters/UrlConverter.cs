using System.Collections.Generic;
using System.Linq;

namespace Common.Utilities.Converters
{
    public class UrlConverter
    {
        static public string GetFirstSegment(string value)
        {
            return value.Split('/').FirstOrDefault(i => !string.IsNullOrEmpty(i));
        }

        static public string GetLastSegment(string value)
        {
            return value.Split('/').LastOrDefault(i => !string.IsNullOrEmpty(i));
        }

        static public string ToQueryString(IDictionary<string, string> parameters)
        {
            var array = parameters.Select(i => string.Format("{0}={1}", i.Key, i.Value)).ToArray();

            return "?" + string.Join("&", array);
        }

        public static string ToUrlSlug(string value)
        {
            return Converter.String.ToValidControlId(value);
        }
    }
}