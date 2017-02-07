using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtils
{
    public static class DateTimeUtils
    {
        public static DateTime TimestampToDateTime(double Timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Timestamp).ToLocalTime();
        }

        public static DateTime UnixTimeToDateTime(double unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime();
        }

        public static double DateTimeToTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date.ToLocalTime() - origin.ToLocalTime();
            return diff.TotalMilliseconds;
        }

        public static double DateTimeToUnixTime(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date.ToLocalTime() - origin.ToLocalTime();
            return diff.TotalSeconds;
        }
    }

}
