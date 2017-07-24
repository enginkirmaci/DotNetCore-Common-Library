using Common.Entities.Constants;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Common.Utilities
{
    public class Utils
    {
        static public string MaskEmail(string email, char mask = '*')
        {
            string result = Regex.Replace(email, RegularExp.EMAILMASK, m => new string(mask, m.Length));
            return result;
        }

        static public string GenereteSmsCode()
        {
            var rand = new Random();
            var number = rand.Next(100000, 999999);

            return number.ToString();
        }

        static public string GenerateFilename(string prefix, string extension)
        {
            var date = DateTime.Now;
            return string.Format("{0}-{1}.{2}.{3} {4}-{5}-{6}.{7}",
                prefix,
                date.Year,
                date.Month,
                date.Day,
                date.Hour,
                date.Minute,
                date.Second,
                extension);
        }

        static public void Log(string serverPath, string prefix, string data)
        {
            File.AppendAllText(serverPath + "/" + GenerateFilename(prefix, "txt"), data);
        }

        static public string CorrectPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();

            if (phoneNumber.Length == 10)
                phoneNumber = "+90" + phoneNumber;
            if (phoneNumber.Length == 11)
                phoneNumber = "+9" + phoneNumber;

            return phoneNumber;
        }

        public static string TruncateWords(string text, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;

            // trunctate the text, then remove the partial word at the end
            return Regex.Replace(Truncate(text, maxCharacters, trailingText),
                @"\s+[^\s]+$", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled) + trailingText;
        }

        public static string Truncate(string text, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;
            else
                return text.Substring(0, maxCharacters) + trailingText;
        }

        public static string StripHtml(string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }

        public static string GeneratePassword(int lowercase, int uppercase, int numerics)
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "0123456789";

            Random random = new Random();

            string generated = "!";
            for (int i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    lowers[random.Next(lowers.Length - 1)].ToString()
                );

            for (int i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    uppers[random.Next(uppers.Length - 1)].ToString()
                );

            for (int i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    number[random.Next(number.Length - 1)].ToString()
                );

            return generated.Replace("!", string.Empty);
        }
    }
}