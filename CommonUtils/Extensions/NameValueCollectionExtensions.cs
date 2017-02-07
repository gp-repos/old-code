using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace NameValueCollectionExtensions
{
    public static class NameValueCollectionExtension
    {
        public static string ToString(this NameValueCollection nvc, string Separator)
        {
            List<string> strList = new List<string>();
            foreach (string key in nvc.AllKeys)
                strList.Add(key + "=" + nvc[key]);
            return String.Join(Separator, strList.ToArray());
        }
    }
}
