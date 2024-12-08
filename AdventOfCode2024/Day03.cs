using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public partial class Day03 : IDay
    {
        public long Part1(List<string> data)
        {
            var sum = 0L;
            var regex = MulFunctionRegex();

            foreach (var line in data)
            {
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
            var sum = 0L;
            var regex = ConditionalMulFunctionRegex();

            var instructions = new Queue<string>();
            foreach (var line in data)
            {
                var matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    instructions.Enqueue(match.Value);
                }
            }

            var isMulEnabled = true;
            while (instructions.Count > 0)
            {
                var instruction = instructions.Dequeue();
                if (instruction == "do()")
                {
                    isMulEnabled = true;
                    continue;
                }
                
                if (instruction == "don't()")
                {
                    isMulEnabled = false;
                    continue;
                }

                if (isMulEnabled)
                {
                    var values = instruction.Split(',');
                    var a = int.Parse(values[0][4..]);
                    var b = int.Parse(values[1][..^1]);
                    sum += a * b;
                }
            }

            return sum;
        }

        [GeneratedRegex(@"mul\(\d+,\d+\)")]
        private static partial Regex MulFunctionRegex();

        [GeneratedRegex(@"mul\(\d+,\d+\)|do\(\)|don't\(\)")]
        private static partial Regex ConditionalMulFunctionRegex();
    }
}