using System.Linq;

namespace Translit
{
    public enum TransliterationType
    {
        GOST, ISO
    }

    public static class Transliteration
    {
        private static string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
        private static string[] lat_gost_up = { "A", "B", "V", "G", "D", "E", "Jo", "Zh", "Z", "I", "Jj", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "C", "Ch", "Sh", "Shh", "'", "Y", "", "Eh", "Yu", "Ya" };
        private static string[] lat_iso_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "X", "C", "Ch", "Sh", "Shh", "'", "Y", "", "E", "Yu", "Ya" };

        private static string[] rus_down = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        private static string[] lat_gost_down = { "a", "b", "v", "g", "d", "e", "jo", "zh", "z", "i", "jj", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "c", "ch", "sh", "shh", "", "y", "", "eh", "yu", "ya" };
        private static string[] lat_iso_down = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "x", "c", "ch", "sh", "shh", "", "y", "", "e", "yu", "ya" };

        private static string[] rus_spec = { "Є", "І", "№", "є", "і", "«", "»", "—" };
        private static string[] lat_gost_spec = { "Eh", "I", "#", "eh", "i", "", "", "-" };
        private static string[] lat_iso_spec = { "Ye", "I", "#", "ye", "i", "", "", "-" };

        public static string CyrillicToLatin(string text)
        {
            return CyrillicToLatin(text, TransliterationType.ISO);
        }

        public static string CyrillicToLatin(string text, TransliterationType type)
        {
            string output = text;
            if (type == TransliterationType.ISO)
            {
                for (int i = 0; i < rus_up.Length; i++)
                    output = output.Replace(rus_up[i], lat_iso_up[i]);
                for (int i = 0; i < rus_down.Length; i++)
                    output = output.Replace(rus_down[i], lat_iso_down[i]);
                for (int i = 0; i < rus_spec.Length; i++)
                    output = output.Replace(rus_spec[i], lat_iso_spec[i]);
            }
            else if (type == TransliterationType.GOST)
            {
                for (int i = 0; i < rus_up.Length; i++)
                    output = output.Replace(rus_up[i], lat_gost_up[i]);
                for (int i = 0; i < rus_down.Length; i++)
                    output = output.Replace(rus_down[i], lat_gost_down[i]);
                for (int i = 0; i < rus_spec.Length; i++)
                    output = output.Replace(rus_spec[i], lat_gost_spec[i]);
            }
            return output;
        }

        public static string LatinToCyrillic(string text)
        {
            return LatinToCyrillic(text, TransliterationType.ISO);
        }

        public static string LatinToCyrillic(string text, TransliterationType type)
        {
            string output = text;
            if (type == TransliterationType.ISO)
            {
                string[] lat = lat_iso_up.OrderByDescending(x => x.Length).ToArray();
                for (int i = 0; i < lat.Length; i++)
                    if (lat[i] != "")
                        output = output.Replace(lat[i], rus_up[lat_iso_up.ToList().IndexOf(lat[i])]);
                lat = lat_iso_down.OrderByDescending(x => x.Length).ToArray();
                for (int i = 0; i < lat.Length; i++)
                    if (lat[i] != "")
                        output = output.Replace(lat[i], rus_down[lat_iso_down.ToList().IndexOf(lat[i])]);
            }
            else if (type == TransliterationType.GOST)
            {
                string[] lat = lat_gost_up.OrderByDescending(x => x.Length).ToArray();
                for (int i = 0; i < lat.Length; i++)
                    if (lat[i] != "")
                        output = output.Replace(lat[i], rus_up[lat_gost_up.ToList().IndexOf(lat[i])]);
                lat = lat_gost_down.OrderByDescending(x => x.Length).ToArray();
                for (int i = 0; i < lat.Length; i++)
                    if (lat[i] != "")
                        output = output.Replace(lat[i], rus_down[lat_gost_down.ToList().IndexOf(lat[i])]);
            }
            return output;
        }

    }
}