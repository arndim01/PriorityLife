using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriorityLifeWebInterface.Helper
{
    public static class Extensions
    {
        public static string CleanExtractedText(this string Value)
        {
            return Value.Replace("Evaluation Warning : The document was created with Spire.PDF for .NET.", "").Replace("\n", "").Replace("\r", "").Trim();
        }
        public static string CleanExtractedPhone(this string Value)
        {
            return Value.CleanExtractedText().Replace("_", "").Replace("-", "");
        }
        public static string CleanExtractedEmail(this string Value)
        {
            return Value.CleanExtractedText().Replace("_", "");
        }
        public static string GetFirstValueIfSpaceExist(this string Value)
        {
            string[] splitValue = Value.Split(" ");
            if(splitValue.Length > 1)
            {
                return splitValue[0];
            }
            else
            {
                return Value.Trim();
            }
        }
    }
}
