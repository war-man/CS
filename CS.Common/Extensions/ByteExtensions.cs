using System;
using System.Security.Cryptography;

namespace CS.Common.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Hashes the hmac.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static byte[] HashHMAC(this byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        /// <summary>
        /// Hashes the encode.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static string HashEncode(this byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
