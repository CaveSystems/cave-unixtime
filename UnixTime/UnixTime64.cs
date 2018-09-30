using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Cave.UnixTime
{
    /// <summary>
    /// Provides functions for 64 bit signed unix timestamps.
    /// </summary>
    /// <remarks>
    /// This struct is compatible with marshalling and interop.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct UnixTime64 : IEquatable<UnixTime64>, IComparable<UnixTime64>
    {
        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(UnixTime64 value1, UnixTime64 value2)
        {
            return value1.TimeStamp == value2.TimeStamp;
        }

        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UnixTime64 value1, UnixTime64 value2)
        {
            return value1.TimeStamp != value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(UnixTime64 value1, UnixTime64 value2)
        {
            return value1.TimeStamp > value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(UnixTime64 value1, UnixTime64 value2)
        {
            return value1.TimeStamp >= value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(UnixTime64 value1, UnixTime64 value2)
        {
            return value1.TimeStamp < value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(UnixTime64 value1, UnixTime64 value2)
        {
            return value1.TimeStamp <= value2.TimeStamp;
        }

        /// <summary>
        /// Implements addition of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="seconds">The number of seconds to add</param>
        /// <returns>Returns a 64 bit unix date time</returns>
        public static UnixTime64 operator +(UnixTime64 time, long seconds)
        {
            return time.TimeStamp + seconds;
        }

        /// <summary>
        /// Implements addition of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="timeSpan">The timespan to add</param>
        /// <returns>Returns a 64 bit unix date time</returns>
        public static UnixTime64 operator +(UnixTime64 time, TimeSpan timeSpan)
        {
            return time.TimeStamp + timeSpan.Ticks / TimeSpan.TicksPerSecond;
        }

        /// <summary>
        /// Implements subtraction of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="seconds">The number of seconds to subtract</param>
        /// <returns>Returns a 64 bit unix date time</returns>
        public static UnixTime64 operator -(UnixTime64 time, long seconds)
        {
            return time.TimeStamp - seconds;
        }

        /// <summary>
        /// Implements subtraction of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="timeSpan">The timespan to subtract</param>
        /// <returns>Returns a 64 bit unix date time</returns>
        public static UnixTime64 operator -(UnixTime64 time, TimeSpan timeSpan)
        {
            return time.TimeStamp - timeSpan.Ticks / TimeSpan.TicksPerSecond;
        }

        /// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="UnixTime64"/>.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UnixTime64(long value)
        {
            return new UnixTime64() { TimeStamp = value };
        }

        /// <summary>
        /// Parses a UnixTime64 previously converted to a string with ToString()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnixTime64 Parse(string value)
        {
            return new UnixTime64()
            {
                DateTime = DateTime.ParseExact(value, UnixTime.InterOpDateTimeFormat, CultureInfo.InvariantCulture),
            };
        }

        /// <summary>Converts the specified unix time stamp.</summary>
        /// <param name="timeStamp">The unix time stamp.</param>
        /// <param name="resultKind">Kind of the result.</param>
        /// <param name="overflowCount">Overflow to regard in calculation</param>
        /// <returns>Returns a DateTime value representing the specified timestamp</returns>
        public static DateTime Convert(long timeStamp, DateTimeKind resultKind, int overflowCount = 0)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, resultKind) + TimeSpan.FromTicks(TimeSpan.TicksPerSecond * timeStamp);
            if (overflowCount != 0)
            {
                result += TimeSpan.FromTicks(overflowCount * (TimeSpan.TicksPerSecond << 32));
            }
            return result;
        }

        /// <summary>Converts the specified unix time stamp.</summary>
        /// <param name="timeStamp">The unix time stamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <param name="overflowCount">Overflow to regard in calculation</param>
        /// <returns>Returns a DateTime value representing the specified timestamp</returns>
        public static DateTime ConvertToUTC(long timeStamp, TimeSpan timeZone, int overflowCount = 0)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) - timeZone + TimeSpan.FromTicks(TimeSpan.TicksPerSecond * timeStamp);
            if (overflowCount != 0)
            {
                result += TimeSpan.FromTicks(overflowCount * (TimeSpan.TicksPerSecond << 32));
            }
            return result;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="UnixTime64"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="t">The unix time stamp.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator DateTime(UnixTime64 t)
        {
            return t.DateTime;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="UnixTime64"/>.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UnixTime64(DateTime dateTime)
        {
            return new UnixTime64()
            {
                DateTime = dateTime,
            };
        }

        /// <summary>
        /// Gets a timestamp that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        public static UnixTime64 Now => DateTime.Now;

        /// <summary>
        /// Gets a timestamp that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static UnixTime64 UtcNow => DateTime.UtcNow;

        /// <summary>The time stamp in seconds since 1.1.1970</summary>
        public long TimeStamp;

        /// <summary>Gets or sets the date time.</summary>
        /// <value>The date time.</value>
        public DateTime DateTime
        {
            get
            {
                return new DateTime(1970, 1, 1) + TimeSpan.FromTicks(TimeSpan.TicksPerSecond * TimeStamp);
            }
            set
            {
                TimeStamp = (value.Ticks - new DateTime(1970, 1, 1).Ticks) / TimeSpan.TicksPerSecond;
            }
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return DateTime.ToString(UnixTime.InterOpDateTimeFormat);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. </returns>
        public override int GetHashCode()
        {
            return TimeStamp.GetHashCode();
        }

        /// <summary>Determines whether the specified <see cref="object" />, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UnixTime64) return base.Equals((UnixTime64)obj);
            return false;
        }

        /// <summary>Determines whether the specified <see cref="UnixTime64" />, is equal to this instance.</summary>
        /// <param name="other">The <see cref="UnixTime64" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="UnixTime64" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public bool Equals(UnixTime64 other)
        {
            return TimeStamp.Equals(other.TimeStamp);
        }

        /// <summary>Vergleicht das aktuelle Objekt mit einem anderen Objekt desselben Typs.</summary>
        /// <param name="other">Ein Objekt, das mit diesem Objekt verglichen werden soll.</param>
        /// <returns>
        /// Ein Wert, der die relative Reihenfolge der verglichenen Objekte angibt.Der Rückgabewert hat folgende Bedeutung:Wert Bedeutung Kleiner als 0 (null) Dieses Objekt ist kleiner als der <paramref name="other" />-Parameter.Zero Dieses Objekt ist gleich <paramref name="other" />. Größer als 0 (null) Dieses Objekt ist größer als <paramref name="other" />.
        /// </returns>
        public int CompareTo(UnixTime64 other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }
}