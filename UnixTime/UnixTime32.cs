#region CopyRight 2018
/*
    Copyright (c) 2010-2018 Andreas Rohleder
    All rights reserved
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion
#region Authors & Contributors
/*
   Author:
     Andreas Rohleder <a.rohleder@cavemail.org>

   Contributors:
 */
#endregion Authors & Contributors

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Cave.UnixTime
{
    /// <summary>
    /// Provides functions for 32 bit unsigned unix timestamps.
    /// </summary>
    /// <remarks>
    /// This struct is compatible with marshalling and interop.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    [DebuggerDisplay("{ToString()}")]
    public struct UnixTime32 : IEquatable<UnixTime32>, IComparable<UnixTime32>
    {
        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(UnixTime32 value1, UnixTime32 value2)
        {
            return value1.TimeStamp == value2.TimeStamp;
        }

        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UnixTime32 value1, UnixTime32 value2)
        {
            return value1.TimeStamp != value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(UnixTime32 value1, UnixTime32 value2)
        {
            return value1.TimeStamp > value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(UnixTime32 value1, UnixTime32 value2)
        {
            return value1.TimeStamp >= value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(UnixTime32 value1, UnixTime32 value2)
        {
            return value1.TimeStamp < value2.TimeStamp;
        }

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(UnixTime32 value1, UnixTime32 value2)
        {
            return value1.TimeStamp <= value2.TimeStamp;
        }

        /// <summary>
        /// Implements addition of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="seconds">The number of seconds to add</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 operator +(UnixTime32 time, uint seconds)
        {
            checked
            {
                return time.TimeStamp + seconds;
            }
        }

        /// <summary>
        /// Implements addition of an UnixTime32 and a TimeSpan value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="timeSpan">The TimeSpan to add</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 operator +(UnixTime32 time, TimeSpan timeSpan)
        {
            checked
            {
                return time + (int)timeSpan.TotalSeconds;
            }
        }

        /// <summary>
        /// Implements addition of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="seconds">The number of seconds to add</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 operator +(UnixTime32 time, int seconds)
        {
            checked
            {
                if (seconds < 0)
                {
                    return time - (uint)-seconds;
                }
                return time + (uint)seconds;
            }
        }

        /// <summary>
        /// Implements subtraction of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="seconds">The number of seconds to subtract</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 operator -(UnixTime32 time, uint seconds)
        {
            checked
            {
                return time.TimeStamp - seconds;
            }
        }

        /// <summary>
        /// Implements subtraction of an UnixTime32 and a TimeSpan value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="timeSpan">The TimeSpan to subtract</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 operator -(UnixTime32 time, TimeSpan timeSpan)
        {
            checked
            {
                return time - (int)timeSpan.TotalSeconds;
            }
        }

        /// <summary>
        /// Implements subtraction of an UnixTime32 and a seconds value
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="seconds">The number of seconds to subtract</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 operator -(UnixTime32 time, int seconds)
        {
            checked
            {
                if (seconds < 0)
                {
                    return time + (uint)-seconds;
                }
                return time - (uint)seconds;
            }
        }

        /// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="UnixTime32"/>.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UnixTime32(uint value)
        {
            return new UnixTime32() { TimeStamp = value };
        }

        /// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="UnixTime32"/>.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UnixTime32(int value)
        {
            checked
            {
                return new UnixTime32() { TimeStamp = (uint)value };
            }
        }

        /// <summary>
        /// Parses a UnixTime32 previously converted to a string with ToString()
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static UnixTime32 Parse(string value)
        {
            return new UnixTime32()
            {
                DateTime = DateTime.ParseExact(value, UnixTime.InterOpDateTimeFormat, CultureInfo.InvariantCulture),
            };
        }

        /// <summary>
        /// Gets a timestamp that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        public static UnixTime32 Now => DateTime.Now;

        /// <summary>
        /// Gets a timestamp that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static UnixTime32 UtcNow => DateTime.UtcNow;

        /// <summary>Converts the specified date time.</summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="overflow">Overflow count for the specified dateTime.</param>
        /// <returns>Returns a 32 bit unsigned unix date time</returns>
        public static uint Convert(DateTime dateTime, out int overflow)
        {
            long result = ((dateTime.Ticks - new DateTime(1970, 1, 1).Ticks) / TimeSpan.TicksPerSecond);
            if (result > uint.MaxValue)
            {
                overflow = (int)(result >> 32);
                result &= 0xFFFFFFFF;
            }
            else
            {
                overflow = 0;
            }
            return (uint)result;
        }

        /// <summary>Converts the specified unix time stamp.</summary>
        /// <param name="timeStamp">The unix time stamp.</param>
        /// <param name="resultKind">Kind of the result.</param>
        /// <param name="overflowCount">Overflow to regard in calculation</param>
        /// <returns>Returns a DateTime value representing the specified timestamp</returns>
        public static DateTime Convert(uint timeStamp, DateTimeKind resultKind, int overflowCount)
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
        public static DateTime ConvertToUTC(uint timeStamp, TimeSpan timeZone, int overflowCount)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) - timeZone + TimeSpan.FromTicks(TimeSpan.TicksPerSecond * timeStamp);
            if (overflowCount != 0)
            {
                result += TimeSpan.FromTicks(overflowCount * (TimeSpan.TicksPerSecond << 32));
            }
            return result;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="UnixTime32"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="t">The unix time stamp.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator DateTime(UnixTime32 t)
        {
            return t.DateTime;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="UnixTime32"/>.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UnixTime32(DateTime dateTime)
        {
            return new UnixTime32()
            {
                DateTime = dateTime,
            };
        }

        /// <summary>The time stamp in seconds since 1.1.1970, this will overflow in 2038</summary>
        public uint TimeStamp;

        /// <summary>Gets or sets the date time.</summary>
        /// <value>The date time.</value>
        public DateTime DateTime
        {
            get
            {
                return Convert(TimeStamp, DateTimeKind.Unspecified, UnixTime.OverflowCount);
            }
            set
            {
                TimeStamp = Convert(value, out int overflow);
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
            if (obj is UnixTime32) return base.Equals((UnixTime32)obj);
            return false;
        }

        /// <summary>Determines whether the specified <see cref="UnixTime32" />, is equal to this instance.</summary>
        /// <param name="other">The <see cref="UnixTime32" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="UnixTime32" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public bool Equals(UnixTime32 other)
        {
            return TimeStamp.Equals(other.TimeStamp);
        }

        /// <summary>Vergleicht das aktuelle Objekt mit einem anderen Objekt desselben Typs.</summary>
        /// <param name="other">Ein Objekt, das mit diesem Objekt verglichen werden soll.</param>
        /// <returns>
        /// Ein Wert, der die relative Reihenfolge der verglichenen Objekte angibt.Der Rückgabewert hat folgende Bedeutung:Wert Bedeutung Kleiner als 0 (null) Dieses Objekt ist kleiner als der <paramref name="other" />-Parameter.Zero Dieses Objekt ist gleich <paramref name="other" />. Größer als 0 (null) Dieses Objekt ist größer als <paramref name="other" />.
        /// </returns>
        public int CompareTo(UnixTime32 other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }
    }
}