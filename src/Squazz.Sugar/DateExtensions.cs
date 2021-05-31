using System;
using System.Globalization;

namespace Squazz.Sugar
{
    public static class DateExtensions
    {
        public static int? ConvertDateToInt(this DateTime? date)
        {
            if (!date.HasValue)
                return (int?)null;

            if (int.TryParse(date.Value.ToString("yyyyMMdd"), out var result))
            {
                return result;
            }

            return (int?)null;
        }

        public static int ConvertDateToInt(this DateTime date)
        {
            if (int.TryParse(date.ToString("yyyyMMdd"), out var result))
            {
                return result;
            }

            return 0;
        }


        public static DateTime? ConvertIntToDateTime(this int? dataTimeLong)
        {
            if (!dataTimeLong.HasValue || dataTimeLong.Value == 0)
                return (DateTime?)null;

            if (DateTime.TryParseExact(dataTimeLong.ToString(), "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }

            return (DateTime?)null;
        }
    }
}
