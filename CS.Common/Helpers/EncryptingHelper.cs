// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="EncryptingHelper.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Class EncryptingHelper.
    /// </summary>
    public static class EncryptingHelper
    {
        #region MD5
        /// <summary>
        /// The MD5 hash
        /// </summary>
        private static MD5 md5Hash = MD5.Create();
        /// <summary>
        /// ms the d5 hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string MD5Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// ms the d5 verify.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="hash">The hash.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool MD5Verify(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = MD5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return (0 == comparer.Compare(hashOfInput, hash));
        }

        /// <summary>
        /// ms the d5 hash bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] MD5HashBytes(byte[] bytes)
        {
            // Convert the input string to a byte array and compute the hash.
            return md5Hash.ComputeHash(bytes);
        }
        #endregion

        #region AES
        /// <summary>
        /// Aeses the encrypt.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string AesEncrypt(string value, string key, string salt)
        {
            salt = GetSalt(salt);
            DeriveBytes rgb = new Rfc2898DeriveBytes(key, Encoding.Unicode.GetBytes(salt));

            byte[] rgbKey = rgb.GetBytes(256 >> 3);
            byte[] rgbIV = rgb.GetBytes(128 >> 3);

            return AesEncrypt(value, rgbKey, rgbIV, Encoding.Unicode);

            //using (Aes aes = Aes.Create())
            //{
            //    byte[] rgbKey = rgb.GetBytes(aes.KeySize >> 3);
            //    byte[] rgbIV = rgb.GetBytes(aes.BlockSize >> 3);

            //    ICryptoTransform transform = aes.CreateEncryptor(rgbKey, rgbIV);

            //    using (MemoryStream buffer = new MemoryStream())
            //    {
            //        using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
            //        {
            //            using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
            //            {
            //                writer.Write(value);
            //            }
            //        }

            //        return Convert.ToBase64String(buffer.ToArray());
            //    }
            //}
        }

        /// <summary>
        /// Encryting input string with Aes crypto
        /// </summary>
        /// <param name="value">Input string</param>
        /// <param name="rgbKey">Secret key for the symmetric algorithm</param>
        /// <param name="rgbIV">Initialization vector (IV) for the symmetric algorithm</param>
        /// <param name="encoding">Input string encoding</param>
        /// <returns>Encrypted base64 string</returns>
        public static string AesEncrypt(string value, byte[] rgbKey, byte[] rgbIV, Encoding encoding)
        {
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform transform = aes.CreateEncryptor(rgbKey, rgbIV);

                using (MemoryStream buffer = new MemoryStream())
                {
                    using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream, encoding))
                        {
                            writer.Write(value);
                        }
                    }

                    return Convert.ToBase64String(buffer.ToArray());
                }
            }
        }

        /// <summary>
        /// Aeses the decrypt.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string AesDecrypt(string text, string key, string salt)
        {
            salt = GetSalt(salt);
            DeriveBytes rgb = new Rfc2898DeriveBytes(key, Encoding.Unicode.GetBytes(salt));

            byte[] rgbKey = rgb.GetBytes(256 >> 3);
            byte[] rgbIV = rgb.GetBytes(128 >> 3);

            return AesDecrypt(text, rgbKey, rgbIV, Encoding.Unicode);

            //using (Aes aes = Aes.Create())
            //{
            //    byte[] rgbKey = rgb.GetBytes(aes.KeySize >> 3);
            //    byte[] rgbIV = rgb.GetBytes(aes.BlockSize >> 3);

            //    ICryptoTransform transform = aes.CreateDecryptor(rgbKey, rgbIV);

            //    using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
            //    {
            //        using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
            //        {
            //            using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
            //            {
            //                return reader.ReadToEnd();
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Decryting input string with Aes crypto
        /// </summary>
        /// <param name="text">Input base64 encrypted string</param>
        /// <param name="rgbKey">Secret key for the symmetric algorithm</param>
        /// <param name="rgbIV">Initialization vector (IV) for the symmetric algorithm</param>
        /// <param name="encoding">Input string encoding</param>
        /// <returns>Decrypted string</returns>
        public static string AesDecrypt(string text, byte[] rgbKey, byte[] rgbIV, Encoding encoding)
        {
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform transform = aes.CreateDecryptor(rgbKey, rgbIV);

                using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
                {
                    using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream, encoding))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the salt.
        /// </summary>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        private static string GetSalt(string salt)
        {
            if (string.IsNullOrEmpty(salt))
                return "fpt00001";

            if (salt.Length < 8)
                return salt + "fpt00001";

            return salt;
        }
        #endregion

        #region Hmac256
        /// <summary>
        /// Hmac256s the hash.
        /// </summary>
        /// <param name="secretkey">The secretkey.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// secretkey
        /// or
        /// data
        /// </exception>
        public static byte[] Hmac256Hash(byte[] secretkey, string data)
        {
            if (secretkey == null)
                throw new ArgumentNullException(nameof(secretkey));

            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            // Initialize the keyed hash object.
            using (HMACSHA256 hmac = new HMACSHA256(secretkey))
            {
                // Compute the hash of the input file.
                byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return hashValue;
            }
        }

        /// <summary>
        /// Hmac256s the hash.
        /// </summary>
        /// <param name="secretkey">The secretkey.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// secretkey
        /// or
        /// data
        /// </exception>
        public static byte[] Hmac256Hash(string secretkey, string data)
        {
            if (secretkey == null)
                throw new ArgumentNullException(nameof(secretkey));

            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            // Initialize the keyed hash object.
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretkey)))
            {
                // Compute the hash of the input file.
                byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return hashValue;
            }
        }

        /// <summary>
        /// Hmac256s the hash.
        /// </summary>
        /// <param name="secretkey">The secretkey.</param>
        /// <param name="inStream">The in stream.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">secretkey</exception>
        /// <exception cref="ArgumentNullException">inStream</exception>
        /// <exception cref="ArgumentException">Input stream must be readable.</exception>
        public static string Hmac256Hash(byte[] secretkey, Stream inStream)
        {
            if (secretkey == null)
                throw new ArgumentNullException(nameof(secretkey));

            if (inStream == null)
                throw new ArgumentNullException(nameof(inStream));

            if (!inStream.CanRead)
                throw new ArgumentException("Input stream must be readable.");

            // Initialize the keyed hash object.
            using (HMACSHA256 hmac = new HMACSHA256(secretkey))
            {
                // Compute the hash of the input file.
                byte[] hashValue = hmac.ComputeHash(inStream);
                return ByteArrayToHexString(hashValue);
            }
        }

        /// <summary>
        /// Hmac256s the verify.
        /// </summary>
        /// <param name="secretkey">The secretkey.</param>
        /// <param name="inStream">The in stream.</param>
        /// <param name="hashedValue">The hashed value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">secretkey</exception>
        /// <exception cref="ArgumentNullException">inStream</exception>
        /// <exception cref="ArgumentException">Input stream must be readable.</exception>
        public static bool Hmac256Verify(byte[] secretkey, Stream inStream, string hashedValue)
        {
            if (secretkey == null)
                throw new ArgumentNullException(nameof(secretkey));

            if (inStream == null)
                throw new ArgumentNullException(nameof(inStream));

            if (!inStream.CanRead)
                throw new ArgumentException("Input stream must be readable.");

            bool valid = true;
            // Initialize the keyed hash object. 
            using (HMACSHA256 hmac = new HMACSHA256(secretkey))
            {
                // Compute the hash of contents of the file.
                byte[] computedHash = hmac.ComputeHash(inStream);
                string computedValue = ByteArrayToHexString(computedHash);
                valid = (computedValue == hashedValue);
            }
            return valid;
        }

        /// <summary>
        /// Bytes the array to hexadecimal string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        private static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        #endregion

        #region RSA
        /// <summary>
        /// Verify the signed data with original content
        /// </summary>
        /// <param name="signedMessage">Signed data in base64 format</param>
        /// <param name="originalMessage">Original content</param>
        /// <param name="publicKey">The public key in PEM format</param>
        /// <param name="encoding">Encoding of original content</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool RSACheckSign(string signedMessage, string originalMessage, string publicKey, Encoding encoding)
        {
            PemReader pr = new PemReader(new StringReader(publicKey));
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)pr.ReadObject());
            return RSACheckSign(signedMessage, originalMessage, rsaParams, encoding);
        }

        /// <summary>
        /// Verify the signed data with original content
        /// </summary>
        /// <param name="signedMessage">Signed data in base64 format</param>
        /// <param name="originalMessage">Original content</param>
        /// <param name="publicKey">The RSA public key parameters</param>
        /// <param name="encoding">Encoding of original content</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool RSACheckSign(string signedMessage, string originalMessage, RSAParameters publicKey, Encoding encoding)
        {
            bool success = false;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                byte[] bytesToVerify = encoding.GetBytes(originalMessage);
                byte[] signedBytes = Convert.FromBase64String(signedMessage);
                try
                {
                    // Sign the data, using SHA1 as the hashing algorithm 
                    success = rsa.VerifyData(bytesToVerify, new SHA1CryptoServiceProvider(), signedBytes);
                }
                catch (CryptographicException)
                {
                    throw;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        /// <summary>
        /// RSASign the input string with private key
        /// </summary>
        /// <param name="content">Input content</param>
        /// <param name="privateKey">PEM format private key</param>
        /// <param name="encoding">Encoding of content</param>
        /// <returns>Signed base64 string</returns>
        public static string RSASign(string content, string privateKey, Encoding encoding)
        {
            byte[] contentBytes = encoding.GetBytes(content);
            byte[] signedBytes = RSASign(contentBytes, privateKey);
            return Convert.ToBase64String(signedBytes);
        }

        /// <summary>
        /// RSASign the input string with private key
        /// </summary>
        /// <param name="content">Input content</param>
        /// <param name="rsaParams">RSA private key parameters</param>
        /// <param name="encoding">Encoding of content</param>
        /// <returns>Signed base64 string</returns>
        public static string RSASign(string content, RSAParameters rsaParams, Encoding encoding)
        {
            byte[] contentBytes = encoding.GetBytes(content);
            byte[] signedBytes = RSASign(contentBytes, rsaParams);
            return Convert.ToBase64String(signedBytes);
        }

        /// <summary>
        /// RSASign the input bytes with private key
        /// </summary>
        /// <param name="content">Input bytes</param>
        /// <param name="privateKey">PEM format private key</param>
        /// <returns>Signed bytes</returns>
        /// <exception cref="ArgumentNullException">content</exception>
        /// <exception cref="ArgumentNullException">privateKey</exception>
        public static byte[] RSASign(byte[] content, string privateKey)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            PemReader pr = new PemReader(new StringReader(privateKey));
            AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)KeyPair.Private);

            return RSASign(content, rsaParams);
        }

        /// <summary>
        /// RSAs the sign.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentNullException">content</exception>
        public static byte[] RSASign(byte[] content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            PemReader pr = new PemReader(File.OpenText("TEK_dev_privatekey.pem"));
            AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)KeyPair.Private);

            return RSASign(content, rsaParams);
        }

        /// <summary>
        /// RSASign the input bytes with private key
        /// </summary>
        /// <param name="content">Input bytes</param>
        /// <param name="rsaParams">The RSA parameters.</param>
        /// <returns>Signed bytes</returns>
        /// <exception cref="ArgumentNullException">content</exception>
        public static byte[] RSASign(byte[] content, RSAParameters rsaParams)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            byte[] signedBytes;
            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.ImportParameters(rsaParams);
                    // Sign the data, using SHA1 as the hashing algorithm 
                    signedBytes = rsa.SignData(content, new SHA1CryptoServiceProvider());
                }
                catch (CryptographicException)
                {
                    throw;
                }
                finally
                {
                    // Set the keycontainer to be cleared when rsa is garbage collected.
                    rsa.PersistKeyInCsp = false;
                }
            }

            return signedBytes;
        }

        #endregion

    }
}
