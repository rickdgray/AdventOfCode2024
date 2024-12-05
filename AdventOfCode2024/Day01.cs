namespace AdventOfCode2024
{
    public class Day01 : IDay
    {
        public long Part1(List<string> data)
        {
            var left_list = new List<long>();
            var right_list = new List<long>();
            foreach (var line in data)
            {
                left_list.Add(long.Parse(line.Split("   ")[0]));
                right_list.Add(long.Parse(line.Split("   ")[1]));
            }

            left_list.Sort();
            right_list.Sort();

            var sumOfDiff = 0L;
            for (int i = 0; i < left_list.Count; i++)
            {
                sumOfDiff += Math.Abs(right_list[i] - left_list[i]);
            }

            return sumOfDiff;
        }

        public long Part2(List<string> data)
        {
            return 0;
        }
    }
}