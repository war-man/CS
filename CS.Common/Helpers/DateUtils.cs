using System;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Class DateUtils.
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// Converts to string with default.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        public static string ConvertToStringWithDefault(DateTime? date, string format = "")
        {
            var val = date.HasValue ? date.Value : DateTime.Now;
            return !string.IsNullOrEmpty(format) ? val.ToString(format) : val.ToString();
        }
    }
}
