using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Collections
{
    public static class StringValidationExtensions
    {
        private static readonly Regex PhoneRegex =
       new(@"^(?:\+20|0)(?:10|11|12|15)\d{8}$", RegexOptions.Compiled);

        private static readonly Regex NationalIdRegex =
            new(@"^[23]\d{13}$", RegexOptions.Compiled);
        extension(string input)
        {
            public bool IsValidEgyptianPhone()
            {
                if (string.IsNullOrWhiteSpace(input))
                    return false;

                return PhoneRegex.IsMatch(input);
            }
            public bool IsValidEgyptianNationalId()
            {
                if (string.IsNullOrWhiteSpace(input))
                    return false;

                return NationalIdRegex.IsMatch(input);
            }

        }
        

        
    }
}
