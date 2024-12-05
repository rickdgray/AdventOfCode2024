namespace AdventOfCode2024
{
    public class Day02 : IDay
    {
        public long Part1(List<string> data)
        {
            var safe = 0L;

            foreach (var line in data)
            {
                var levels = line.Split(' ').Select(long.Parse).ToList() ?? [];

                var diffs = new List<long>();
                for (int i = 1; i < levels.Count; i++)
                {
                    diffs.Add(levels[i] - levels[i - 1]);
                }

                if (!diffs.All(d => d > 0) && !diffs.All(d => d < 0))
                {
                    continue;
                }

                if (diffs.Any(d => d == 0))
                {
                    continue;
                }

                if (diffs.Any(d => Math.Abs(d) > 3))
                {
                    continue;
                }

                safe++;
            }

            return safe;
        }

        public long Part2(List<string> data)
        {
            var safe = 0L;

            foreach (var line in data)
            {
                var allLevels = line.Split(' ').Select(long.Parse).ToList() ?? [];

                var isSafe = false;
                for (int i = 0; i < allLevels.Count; i++)
                {
                    var levels = new List<long>(allLevels);
                    levels.RemoveAt(i);

                    var diffs = new List<long>();
                    for (int j = 1; j < levels.Count; j++)
                    {
                        diffs.Add(levels[j] - levels[j - 1]);
                    }

                    if (!diffs.All(d => d > 0) && !diffs.All(d => d < 0))
                    {
                        continue;
                    }

                    if (diffs.Any(d => d == 0))
                    {
                        continue;
                    }

                    if (diffs.Any(d => Math.Abs(d) > 3))
                    {
                        continue;
                    }

                    isSafe = true;
                    break;
                }

                if (isSafe)
                {
                    safe++;
                }
            }

            return safe;
        }
    }
}