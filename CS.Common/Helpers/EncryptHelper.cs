// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="EncryptHelper.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Enum SNKeyLength
    /// </summary>
    public enum SNKeyLength
    {
        /// <summary>
        /// The s N16
        /// </summary>
        SN16 = 16, SN20 = 20, SN24 = 24, SN28 = 28, SN32 = 32
    }

    /// <summary>
    /// Enum SNKeyNumLength
    /// </summary>
    public enum SNKeyNumLength
    {
        /// <summary>
        /// The s n4
        /// </summary>
        SN4 = 4, SN8 = 8, SN12 = 12
    }

    /// <summary>
    /// Class EncryptHelper.
    /// </summary>
    public static class EncryptHelper
    {
        /// <summary>
        /// Appends the specified string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="str">The string.</param>
        /// <param name="newKey">The new key.</param>
        /// <returns>System.String.</returns>
        private static string AppendSpecifiedStr(int length, string str, char[] newKey)
        {
            string
            newKeyStr = "";
            int k = 0;
            for (int i = 0; i < length; i++)
            {
                for
                (k = i; k < 4 + i; k++)
                {
                    newKeyStr += newKey[k];
                }
                if (k ==
                length)
                {
                    break;
                }
                else
                {
                    i = (k) - 1;
                    newKeyStr +=
                    str;
                }
            }
            return newKeyStr;
        }

        /// <summary>
        /// Gets the serial key alpha numeric.
        /// </summary>
        /// <param name="keyLength">Length of the key.</param>
        /// <returns>System.String.</returns>
        public static string GetSerialKeyAlphaNumeric(SNKeyLength keyLength)
        {
            Guid newguid = Guid.NewGuid();
            string randomStr =
            newguid.ToString("N");
            string tracStr = randomStr.Substring(0,
            (int)keyLength);
            tracStr = tracStr.ToUpper();
            char[] newKey =
            tracStr.ToCharArray();
            string newSerialNumber = "";
            switch (keyLength
            )
            {
                case SNKeyLength.SN16:
                    newSerialNumber = AppendSpecifiedStr(16, "-", newKey);
                    break;
                case SNKeyLength.SN20:
                    newSerialNumber = AppendSpecifiedStr(20, "-", newKey);
                    break;
                case SNKeyLength.SN24:
                    newSerialNumber = AppendSpecifiedStr(24, "-", newKey);
                    break;
                case SNKeyLength.SN28:
                    newSerialNumber = AppendSpecifiedStr(28, "-", newKey);
                    break;
                case SNKeyLength.SN32:
                    newSerialNumber = AppendSpecifiedStr(32, "-", newKey);
                    break;
            }

            return newSerialNumber;
        }

        /// <summary>
        /// Gets the serial key numeric.
        /// </summary>
        /// <param name="keyLength">Length of the key.</param>
        /// <returns>System.String.</returns>
        public static string GetSerialKeyNumeric(SNKeyNumLength keyLength)
        {
            Random rn = new Random();
            double sd = Math.Round(rn.NextDouble() * Math.Pow(10, (int)keyLength) + 4);
            return sd.ToString().Substring(0, (int)keyLength);
        }
    }
}