using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtils
{
    public static class HumanUtils
    {
        public static int GetGenderByName(string LastName, int iMaleID, int iFemaleID)
        {
            if (LastName == "") return 0;

            string lastchar = LastName.Substring(LastName.Length - 1, 1);
            if ((lastchar == "а") || (lastchar == "я"))
                return iFemaleID;
            else
                return iMaleID;
        }
    }

}
