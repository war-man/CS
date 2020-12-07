using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CS.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Converts to snakecase.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
        // Check Tekmedi card
        public static bool ValidateCardNumber(string cardNumber)
        {
            Regex rx = new Regex(@"^79[0-9]{10}$");
            return rx.IsMatch(cardNumber);
        }
        public static string MapValidPatientCode(string patientCode)
        {
            string mapHopitalCode = "079048.";
            if (!patientCode.Contains(mapHopitalCode))
                patientCode = mapHopitalCode + patientCode;
            return patientCode;
        }
        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.Match(phoneNumber, @"(84|0[3|5|7|8|9])+([0-9]{8})\b").Success;
        }
        public static string ConvertToValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+84"))
            {
                phoneNumber = $"0{phoneNumber.Substring(3)}";
            }
            if (phoneNumber.StartsWith("84"))
            {
                phoneNumber = $"0{phoneNumber.Substring(2)}";
            }
            return phoneNumber;
        }
        public static string GenerateShortener()
        {
            string urlsafe = string.Empty;
            Enumerable.Range(48, 75).Where(i => i < 58 || i > 64 && i < 91 || i > 96).OrderBy(o => new Random().Next()).ToList().ForEach(i => urlsafe += Convert.ToChar(i));
            return urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
        }
        public static string Hex2utf8(string hex)
        {
            try
            {
                var encodedBytes = Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
                var utf8 = new UTF8Encoding();
                var decodedString = utf8.GetString(encodedBytes);
                return decodedString;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static bool IsPossibleHexStr(string str)
        {
            return str.Length > 10;
        }
        public static bool IsBirthYear(string str)
        {
            return str.Length == 4 && int.TryParse(str, out _);
        }
        public static bool IsDate(string str)
        {
            return DateTime.TryParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _);
        }
        public static bool IsPlaceCode(string str)
        {
            return str.Length == 8 && str[3] == '-';
        }
        public static bool IsGender(string str)
        {
            return str == "1" || str == "2";
        }
        public static string NormalizeAddress(string address)
        {
            return address
               .Trim()
               .ToLower()
               .Replace("tp", "thành phố")
               .Replace("tỉnh", "")
               .Replace("t.", "")
               .Replace("thành phố", "")
               .Replace("huyện", "")
               .Replace("xã", "")
               .Replace("quận", "")
               .Replace("phường", "")
               .Replace("p.", "")
               .Replace("thị trấn", "")
               .Replace(",", "")
               .Replace(".", "")
               .Replace(" ", "");
        }
        public static string ConvertStringToHex(String input, Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
        public static string ConvertHexToString(String hexInput, Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }

        public static string TruncatePatientName(string text)
        {
            text = text.Trim();
            if (text.LastIndexOf(' ') != -1)
            {
                var lastNameTemp = text.Substring(text.LastIndexOf(' '));
                var firstNameTemp = text.Substring(0, text.LastIndexOf(' ')).Split(" ");
                var splitName1 = "";
                var splitName2 = "";

                if (text.Length >= 20)
                {
                    for (var i = 0; i < firstNameTemp.Length; i++)
                    {
                        if (i >= 2)
                            splitName2 += firstNameTemp[i].Substring(0, 1) + " ";
                        else
                            splitName1 += firstNameTemp[i] + " ";
                    }
                    return splitName1 + splitName2 + lastNameTemp;
                }
            }
            return text;
        }

        public static T ConvertStringToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        public static string ConvertObjectToString<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
