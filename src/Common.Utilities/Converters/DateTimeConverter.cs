using System;
using System.Globalization;

namespace Common.Utilities.Converters
{
    public class DateTimeConverter
    {
        private CultureInfo turkish = new CultureInfo("tr-TR");

        public int ToEpochSeconds(DateTime? date, bool useAsUTC = false)
        {
            if (date.HasValue)
            {
                if (useAsUTC)
                {
                    //piece of shit coding
                    return (int)(date.Value - new DateTime(1970, 1, 1)).TotalSeconds;
                }
                return (int)(date.Value.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
            }
            else
            {
                return 0;
            }
        }

        public int ToEpochSeconds(DateTime? date, int hoursToAdd)
        {
            if (date.HasValue)
            {
                if (hoursToAdd != 0)
                {
                    //piece of shit coding
                    return (int)(date.Value.AddHours(hoursToAdd) - new DateTime(1970, 1, 1)).TotalSeconds;
                }
                return (int)(date.Value - new DateTime(1970, 1, 1)).TotalSeconds;
            }
            else
            {
                return 0;
            }
        }

        public string ToDayMonthDayname(DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;

            return date.Value.ToString("dd MMMM dddd", turkish);
        }

        public string ToMonthDayYear(DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;

            return date.Value.ToString("MMMM dd, yyyy");
        }

        public string ToShortTr(DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;

            return date.Value.ToString("dd MMMM yyyy", turkish);
        }

        public string ToTimeString(DateTime? date)
        {
            if (!date.HasValue)
                return string.Empty;

            return date.Value.ToString("HH:mm", turkish);
        }
    }
}