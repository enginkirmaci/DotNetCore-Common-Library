using Common.Entities.Constants;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utilities.Converters
{
    public class StringConverter
    {
        private CultureInfo turkish = new CultureInfo("tr-TR");

        public string TurkishCharsToEnglish(string text)
        {
            var olds = new string[] { "Ğ", "ğ", "Ü", "ü", "Ş", "ş", "İ", "ı", "Ö", "ö", "Ç", "ç" };
            var news = new string[] { "G", "g", "U", "u", "S", "s", "I", "i", "O", "o", "C", "c" };

            if (text != null)
                for (var i = 0; i < olds.Length; i++)
                    text = text.Replace(olds[i], news[i]);

            return text;
        }

        public string ToValidControlId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            //First to lower case
            value = TurkishCharsToEnglish(value).ToLowerInvariant();

            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);

            value = Encoding.ASCII.GetString(bytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "_", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or \_
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }

        public string ToFullName(string firstName, string lastName)
        {
            return string.Format("{0} {1}", firstName, lastName);
        }

        public string ToUpperTurkish(string value)
        {
            return value.ToUpper(turkish);
        }

        public void SplitFirstLastName(string fullName, out string firstName, out string lastName)
        {
            firstName = lastName = string.Empty;

            Match match = Regex.Match(fullName, RegularExp.FIRSTLASTNAMEMATCH);
            if (match.Success)
            {
                firstName = match.Groups["first"].Value;
                lastName = match.Groups["last"].Value;
                if (match.Groups["middle"].Success)
                {
                    firstName += " " + match.Groups["middle"].Value;
                }
            }
            else
            {
                firstName = fullName.Split(' ').FirstOrDefault();
                lastName = fullName.Split(' ').LastOrDefault();
            }
        }
    }
}