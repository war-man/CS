// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="DateTimeUtils.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using static CS.Common.Common.Constants;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Class DateTimeUtils.
    /// </summary>
    public static class DateTimeUtils
    {
        /// <summary>
        /// <para>Truncates a DateTime to a specified resolution.</para>
        /// <para>A convenient source for resolution is TimeSpan.TicksPerXXXX constants.</para>
        /// </summary>
        /// <param name="date">The DateTime object to truncate</param>
        /// <param name="resolution">e.g. to round to nearest second, TimeSpan.TicksPerSecond</param>
        /// <returns>Truncated DateTime</returns>
        public static DateTime Truncate(this DateTime date, long resolution)
        {
            return new DateTime(date.Ticks - (date.Ticks % resolution), date.Kind);
        }

        /// <summary>
        /// Truncates the specified resolution.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="resolution">The resolution.</param>
        /// <returns></returns>
        public static DateTime Truncate(this DateTime? date, long resolution)
        {
            var dateVal = date != null && date.HasValue ? date.Value : DateTime.Now;
            return new DateTime(dateVal.Ticks - (dateVal.Ticks % resolution), dateVal.Kind);
        }
        /// <summary>
        /// Checks the valid datetime.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool CheckValidDatetime(string date)
        {
            if (!DateTime.TryParseExact(date, DateTimeFormatConstants.YYYYMMDDTHHMMSSZ, CultureInfo.InvariantCulture,
                      DateTimeStyles.None, out DateTime validDate))
                return false;
            return true;
        }
        /// <summary>
        /// Calculators the age.
        /// </summary>
        /// <param name="birthday">The birthday.</param>
        /// <returns></returns>
        public static string CalculatorAge(DateTime birthday)
        {
            var reference = DateTime.Now;
            int age = reference.Year - birthday.Year;
            if (reference < birthday.AddYears(age)) age--;
            return age.ToString();
        }
    }
}
