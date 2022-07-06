using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Maynor
{
    public static class StringExtensionMethods
    {

        /// <summary>Indicates whether the specified string is null or a <see cref="string.Empty"/>.</summary>
        public static bool IsNullOrEmpty(this string seed) { return string.IsNullOrEmpty(seed); }

        /// <summary>Indicates whether the specified string is null or a <see cref="string.Empty"/> or just spacebar characters.</summary>
        public static bool IsNullOrWhitespace(this string seed) { return string.IsNullOrWhiteSpace(seed); }

        /// <summary>Returns true if the string is formatted as a valid email address.</summary>
        public static bool IsValidEmailAddress(this string seed)
        {
            bool isValid = false;
            MailAddress address;

            try
            {
                address = new MailAddress(seed);
                isValid = true;
            }
            catch { }
            return isValid;
        }

        public static bool IsValidPhoneNumber(this string number)
        {
            Regex regex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(number);
        }



        /// <summary>Encodes all the characters in the specified string into a sequence of bytes.</summary>
        public static byte[] ToBytes(this string startString, Encoding encoding)
        {
            if (encoding is null) encoding = Encoding.UTF8;
            return encoding.GetBytes(startString);
        }
        public static byte[] ToBytes(this string startString) { return ToBytes(startString, Encoding.UTF8); }

        /// <summary>Decodes the bytes in an array into a string using a specified encoder.</summary>
        public static string FromBytes(this byte[] sourceData, Encoding encoding)
        {
            if (encoding is null) encoding = Encoding.UTF8;
            return encoding.GetString(sourceData);
        }
        public static string FromBytes(this byte[] sourceData) { return FromBytes(sourceData, Encoding.UTF8); }



        /// <summary>Converts plain text to a Base64 encoded string using the UTF8 encoding suitable for the web and obfuscation.</summary>        
        public static string ToBase64String(this string utf8String)
        {
            return Convert.ToBase64String(utf8String.ToBytes());
        }

        /// <summary>Decodes a Base64 string rendering UTF-8 plain text.</summary>        
        public static string FromBase64String(this string base64EncodedData)
        {
            return Convert.FromBase64String(base64EncodedData).FromBytes();
        }


        /// <summary>Converts a byte array to a hexidecimal encoded srting.</summary>        
        public static string ToHexString(this byte[] data)
        {
            return Convert.ToHexString(data);
        }
        public static string ToHexString(this string utf8String)
        {
            return ToHexString(utf8String.ToBytes());
        }
        /// <summary>Converts a hexidecimal encoded string into a byte array.</summary>        
        public static byte[] ToHexBytes(this string hexEncodedString)
        {
            return Convert.FromHexString(hexEncodedString);
        }
    }
}
