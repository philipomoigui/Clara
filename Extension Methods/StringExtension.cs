using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Extension_Methods
{
    public static class StringExtension
    {
        public static string Capitalize(this string input)
        {
            switch (input)
            {
                case null:
                    throw new ArgumentNullException(nameof(input));
                case "":
                    throw new ArgumentNullException($"{nameof(input)} cannot be empty");
                default:
                    return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
