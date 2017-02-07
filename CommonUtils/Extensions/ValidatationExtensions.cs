using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using StringExtensions;

namespace ValidatationExtensions
{
    public static class ValidatationExtension
    {
        public static bool isValidEmail(this string input)
        {
            var match = Regex.Match(input, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static bool isValidUrl(this string input)
        {
            string strRegex = "^(https?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
                + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                + "|" // allows either IP or domain
                + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                + "(:[0-9]{1,5})?" // port number- :80
                + "((/?)|" // a slash isn't required if there is no file name
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return new Regex(strRegex).IsMatch(input);
        }

        public static bool isValidPhone(this string input)
        {
            var match = Regex.Match(input, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static bool isNumber(this string input)
        {
            var match = Regex.Match(input, @"^[0-9]+$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static int extractNumber(this string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return 0;

            var match = Regex.Match(input, "[0-9]+", RegexOptions.IgnoreCase);
            return match.Success ? match.Value.ToInt() : 0;
        }

        public static string extractEmail(this string input)
        {
            if (input == null || String.IsNullOrWhiteSpace(input)) return string.Empty;

            var match = Regex.Match(input, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            return match.Success ? match.Value : string.Empty;
        }

        public static string extractQueryStringParamValue(this string queryString, string paramName)
        {
            if (String.IsNullOrWhiteSpace(queryString) || String.IsNullOrWhiteSpace(paramName)) return string.Empty;

            var query = queryString.Replace("?", "");
            if (!query.Contains("=")) return string.Empty;
            var queryValues = query.Split('&').Select(piQ => piQ.Split('=')).ToDictionary(piKey => piKey[0].ToLower().Trim(), piValue => piValue[1]);
            string result;
            var found = queryValues.TryGetValue(paramName.ToLower().Trim(), out result);
            return found ? result : string.Empty;
        }

    }
}
