using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Spiders.Lou.Domain.Utils
{
    public static class StringExtension
    {
        public static string XToString<T>(this IEnumerable<T> a, string splitor = ",", string wrapper = "", Func<T, string> func = null)
        {
            if (!a.Any()) return "";
            var s = "";
            foreach (var m in a)
            {
                s += $"{wrapper}{(func == null ? m.ToString() : func(m))}{wrapper}{splitor}";
            }
            return s.Substring(0, s.Length - splitor.Length);
        }

        public static int XToIntOr0(this string s)
        {
            return int.TryParse(s, out var result) ? result : 0;
        }

        public static int? XToIntOrNull(this string s)
        {
            return int.TryParse(s, out var result) ? result : null;
        }

        public static DateTime? XToDateTimeOrNull(this string s)
        {
            return DateTime.TryParse(s, out var result) ? result : null;
        }

        public static decimal? XToDecimalOrNull(this string s)
        {
            return decimal.TryParse(s, out var result) ? result : null;
        }

        public static string XFromUtf16Str(this string s)
        {
            if (s == null) return null;
            var bs = new List<byte>();
            foreach (var str in s.Split(@"\u"))
            {
                if (string.IsNullOrWhiteSpace(str)) continue;
                for (int i = 0; i < str.Length - 1; i += 2)
                {
                    bs.Add(Convert.ToByte(str.Substring(i, 2), 16));
                }
            }
            return bs.Any() ? Encoding.BigEndianUnicode.GetString(bs.ToArray()) : "";
        }
    }

    public static class FuncExtension
    {
        public static T WithRetry<T>(this Func<T> func, int times = 10, ILogger? logger = null)
        {
            while (--times > 0)
            {
                try
                {
                    return func();
                }
                catch (Exception ex)
                {
                    if (logger != null)
                        logger.LogError(ex, "[FuncExtension.WithRetry]");
                }
            }
            return func();
        }
    }
}
