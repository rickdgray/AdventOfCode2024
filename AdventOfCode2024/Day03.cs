using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public partial class Day03 : IDay
    {
        public long Part1(List<string> data)
        {
            var sum = 0L;

            foreach (var line in data)
            {
                var regex = MulFunctionRegex();
                var matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    var values = match.Value.Split(',');
                    var a = int.Parse(values[0][4..]);
                    var b = int.Parse(values[1][..^1]);
                    sum += a * b;
                }
            }

            return sum;
        }

        public long Part2(List<string> data)
        {
            throw new NotImplementedException();
        }

        [GeneratedRegex(@"mul\(\d+,\d+\)")]
        private static partial Regex MulFunctionRegex();
    }
}