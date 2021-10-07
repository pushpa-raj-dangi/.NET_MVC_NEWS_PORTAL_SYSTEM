using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsWebApp.Helpers
{
    public class SlugHelper
    {
        public static string GenerateSlug(string inputString)
        {

            inputString = inputString.ToLower().Trim();

            inputString = CleanWhiteSpace(inputString, true);
            inputString = ApplyReplacements(inputString, new Dictionary<string, string>() { { " ", "-" } });
            inputString = RemoveDiacritics(inputString);
            inputString = DeleteCharacters(inputString, @"[^a-zA-Z0-9\-_]");

            inputString = Regex.Replace(inputString, "--+", "-");

            return inputString;
        }

        private static string CleanWhiteSpace(string str, bool collapse)
        {
            return Regex.Replace(str, collapse ? @"\s+" : @"\s", " ");
        }

        private static string RemoveDiacritics(string str)
        {
            var stFormD = str.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string ApplyReplacements(string str, Dictionary<string, string> replacements)
        {
            var sb = new StringBuilder(str);

            foreach (KeyValuePair<string, string> replacement in replacements)
            {
                sb = sb.Replace(replacement.Key, replacement.Value);
            }

            return sb.ToString();
        }

        private static string DeleteCharacters(string str, string regex)
        {
            return Regex.Replace(str, regex, "");
        }
    }
}

