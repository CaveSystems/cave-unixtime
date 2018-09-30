using System.Diagnostics.CodeAnalysis;

namespace Cave.UnixTime
{
    /// <summary>
    /// Global settings for <see cref="UnixTime32"/> and <see cref="UnixTime64"/>
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class UnixTime
    {
        /// <summary>
        /// Provides the default date time string used when formatting date time variables for interop
        /// </summary>
        public static string InterOpDateTimeFormat { get; set; } = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";

        /// <summary>
        /// Provides the default date time string used when formatting date time variables for display
        /// </summary>
        public static string DisplayDateTimeFormat { get; set; } = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";

        /// <summary>
        /// Since UnixTime32 will overflow in 2038 this global setting sets the default over flowcount for calculation.
        /// </summary>
        public static int OverflowCount { get; set; }
    }
}
