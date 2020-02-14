using System;
using System.Globalization;

namespace SimpleDate
{
    [Serializable]
    public struct Date : IFormattable
    {
        private readonly DateTime date;
        public static readonly Date MinValue = DateTime.MinValue;
        public static readonly Date MaxValue = DateTime.MaxValue;

        /// <param name="date">yyyy-MM-dd format</param>
        public Date(string date = null)
        {
            DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out this.date);
        }

        public Date(int year, int month, int day)
        {
            date = new DateTime(year, month, day);
        }

        public Date(DateTime date) : this(date.Year, date.Month, date.Day)
        {
        }

        public Date(DateTimeOffset date) : this(date.Year, date.Month, date.Day)
        {
        }

        public int Year => date.Year;

        public int Month => date.Month;

        public int Day => date.Day;

        public override string ToString()
        {
            return $"{date.Year}-{date.Month.ToString("00")}-{date.Day.ToString("00")}";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                return ToString();
            }
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Date))
            {
                return false;
            }
            return date.Equals(((Date)obj).date);
        }

        public override int GetHashCode()
        {
            return date.GetHashCode();
        }

        public static implicit operator Date(string date)
        {
            return new Date(date);
        }

        public static implicit operator string(Date date)
        {
            return date.ToString();
        }

        public static implicit operator Date(DateTime date)
        {
            return new Date(date.Year, date.Month, date.Day);
        }

        public static implicit operator DateTime(Date date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static implicit operator Date(DateTimeOffset date)
        {
            return new Date(date.Year, date.Month, date.Day);
        }

        public static implicit operator DateTimeOffset(Date date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, TimeSpan.Zero);
        }
    }
}