using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringExtensions
{
    public static class StringExtension
    {

        public static DateTime ToDateTime(this string input, bool throwExceptionIfFailed = false)
        {
            DateTime result;
            var valid = DateTime.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as DateTime", input));
            return result;
        }

        public static int ToInt(this string input, bool throwExceptionIfFailed = false)
        {
            int result;
            var valid = int.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as int", input));
            return result;
        }

        public static double ToDouble(this string input, bool throwExceptionIfFailed = false)
        {
            double result;
            var valid = double.TryParse(input, NumberStyles.AllowDecimalPoint, new NumberFormatInfo { NumberDecimalSeparator = "." }, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new FormatException(string.Format("'{0}' cannot be converted as double", input));
            return result;
        }

        public static string Reverse(this string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return string.Empty;
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        /// <summary>
        /// Matching all capital letters in the input and seperate them with spaces to form a sentence.
        /// If the input is an abbreviation text, no space will be added and returns the same input.
        /// </summary>
        /// <example>
        /// input : HelloWorld
        /// output : Hello World
        /// </example>
        /// <example>
        /// input : BBC
        /// output : BBC
        /// </example>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSentence(this string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return input;
            //return as is if the input is just an abbreviation
            if (Regex.Match(input, "[0-9A-Z]+$").Success) return input;
            //add a space before each capital letter, but not the first one.
            var result = Regex.Replace(input, "(\\B[A-Z])", " $1");
            return result;
        }

        public static string Right(this string input, int Length)
        {
            if (String.IsNullOrWhiteSpace(input)) return string.Empty;
            var value = input.Trim();
            return Length >= value.Length ? value : value.Substring(value.Length - Length);
        }

        public static string Left(this string input, int Length)
        {
            if (String.IsNullOrWhiteSpace(input)) return string.Empty;
            var value = input.Trim();
            return Length >= value.Length ? value : input.Substring(0, Length);
        }

        public static string FirstLetterUp(this string input)
        {
            char[] a = input.ToLower().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static string AllFirstLettersUp(this string input)
        {
            char[] a = input.ToLower().ToCharArray();
            a[0] = char.ToUpper(a[0]);
            for (int i = 1; i < a.Count(); i++)
                a[i] = (a[i - 1] == ' ') ? char.ToUpper(a[i]) : a[i];
            return new string(a);
        }

        /// <summary>
        /// Reduce string to shorter preview which is optionally ended by some string (...).
        /// </summary>
        /// <param name="s">string to reduce</param>
        /// <param name="count">Length of returned string including endings.</param>
        /// <param name="endings">optional edings of reduced text</param>
        /// <example>
        /// string description = "This is very long description of something";
        /// string preview = description.Reduce(20,"...");
        /// produce -> "This is very long..."
        /// </example>
        /// <returns></returns>
        public static string Reduce(this string input, int count, string endings)
        {
            if (count > input.Length)
                return input;
            if (count < endings.Length)
                return input;
            return input.Substring(0, count - endings.Length) + endings;
        }

    }
}
