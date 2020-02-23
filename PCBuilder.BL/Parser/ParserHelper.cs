using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ComputerBuilder.BL.Parser
{
    public static class ParserHelper
    {
        public static string[] SelectByHardwareType (this string source, string pattern)
        {
            Regex regex = new Regex(pattern,RegexOptions.Compiled);
            var matches = regex.Matches(source).Cast<Match>().Select(m => m.Value).ToArray();
            return matches;
        }
        public static double SelectCost(this string source)
        {
            Regex regex = new Regex(@"(?<=')(\d)+", RegexOptions.Compiled);//TODO: Сделать шаблон целые и дробные числа
            var match = regex.Match(source).Value;
            if (double.TryParse(match, out double cost))
                return cost;
            else
                throw new InvalidCastException("Не удалось преобразовать цену",new Exception().InnerException);
        }
        public static string SelectDescription(this string source)
        {
            var description = Regex.Match(source, @"(?<=\()[^\)|[]+").Value;
            return description;
        }
        public static string RemoveSubstring(this string source, string substring)
        {
            return source.Remove(0,substring.Length);
        }

    }
}
