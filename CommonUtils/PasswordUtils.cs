using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtils
{
    public static class PasswordUtils
    {
        public static string GenaratePassword(int PasswordLength, bool bAllowNumbers, bool bAllowChars)
        {
            if ((!bAllowNumbers) && (!bAllowChars))
                return "";

            string strRandom = "QWERTYUIOPAS1234567890DFGHJKLZXCVBNM1234567890qwertyuio1234567890pasdfghjklzxcvbnm1234567890";

            if (!bAllowNumbers)
                strRandom = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            else if (!bAllowChars)
                strRandom = "123456789013579086421470369258";

            string str = "";

            Random rndOne = new Random();
            for (int i = 0; i < PasswordLength; i++)
                str = str + strRandom.Substring(rndOne.Next(strRandom.Length), 1);

            return str;
        }

    }

}
