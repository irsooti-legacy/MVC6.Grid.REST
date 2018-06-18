using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC6.Grid.REST.Extensions
{
    public static class StringExtensions
    {

        public static string ToUnderscoreCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        public static string ToPascalCase(this string s)
        {
            if (s == null)
                return s;
            var words = s.Split(new[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(word => word.Substring(0, 1).ToUpper() +
                                         word.Substring(1).ToLower());

            var result = String.Concat(words);
            return result;
        }

    }
}
