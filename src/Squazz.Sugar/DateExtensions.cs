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

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of ticks from the value of this instance.</summary>
        /// <param name="ticks">A number of 100-nanosecond ticks. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="ticks">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractTicks(this DateTimeOffset dateTimeOffset, int ticks)
        {
            return dateTimeOffset.AddTicks(-ticks);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of milliseconds from the value of this instance.</summary>
        /// <param name="milliseconds">A number of whole and fractional milliseconds. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="milliseconds">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractMilliseconds(this DateTimeOffset dateTimeOffset, int milliseconds)
        {
            return dateTimeOffset.AddMilliseconds(-milliseconds);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of seconds from the value of this instance.</summary>
        /// <param name="seconds">A number of whole and fractional seconds. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="seconds">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractSeconds(this DateTimeOffset dateTimeOffset, int seconds)
        {
            return dateTimeOffset.AddSeconds(-seconds);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of minutes from the value of this instance.</summary>
        /// <param name="minutes">A number of whole and fractional minutes. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="minutes">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractMinutes(this DateTimeOffset dateTimeOffset, int minutes)
        {
            return dateTimeOffset.AddMinutes(-minutes);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of hours from the value of this instance.</summary>
        /// <param name="hours">A number of whole and fractional hours. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="hours">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractHours(this DateTimeOffset dateTimeOffset, int hours)
        {
            return dateTimeOffset.AddHours(-hours);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of days from the value of this instance.</summary>
        /// <param name="days">A number of whole and fractional days. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="days">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractDays(this DateTimeOffset dateTimeOffset, int days)
        {
            return dateTimeOffset.AddDays(-days);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of months from the value of this instance.</summary>
        /// <param name="months">A number of whole months. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="months">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractMonths(this DateTimeOffset dateTimeOffset, int months)
        {
            return dateTimeOffset.AddMonths(-months);
        }

        /// <summary>Returns a new <see cref="T:System.DateTimeOffset"></see> object that subtracts a specified number of years from the value of this instance.</summary>
        /// <param name="years">A number of years. The number can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by the current <see cref="T:System.DateTimeOffset"></see> object and the number of ticks represented by <paramref name="ticks">ticks</paramref>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The resulting <see cref="T:System.DateTimeOffset"></see> value is less than <see cref="F:System.DateTimeOffset.MinValue"></see>.   -or-   The resulting <see cref="T:System.DateTimeOffset"></see> value is greater than <see cref="F:System.DateTimeOffset.MaxValue"></see>.</exception>
        public static DateTimeOffset SubtractYears(this DateTimeOffset dateTimeOffset, int years)
        {
            return dateTimeOffset.AddYears(-years);
        }
    }
}
