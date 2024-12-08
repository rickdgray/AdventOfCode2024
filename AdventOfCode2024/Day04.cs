using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public partial class Day04 : IDay
    {
        public long Part1(List<string> data)
        {
            var regex = XmasRegex();
            var matrix = new List<List<char>>(data.Count * data.First().Length);

            foreach (var line in data)
            {
                matrix.Add([.. line.ToCharArray()]);
            }
            
            var horizontals = matrix
                .Select(row => new string([.. row]))
                .ToList();

            var reverseHorizontals = new List<string>(horizontals.Count);
            foreach (var row in horizontals)
            {
                reverseHorizontals.Add(new string(row.Reverse().ToArray()));
            }

            var verticals = Enumerable
                .Range(0, matrix.First().Count)
                .Select(i => new string(matrix.Select(row => row[i]).ToArray()))
                .ToList();

            var reverseVerticals = new List<string>(verticals.Count);
            foreach (var row in verticals)
            {
                reverseVerticals.Add(new string(row.Reverse().ToArray()));
            }

            var diagonals = new List<string>(matrix.Count + matrix.First().Count - 1);

            // down right diags middle down
            for (var i = 0; i < matrix.Count; i++)
            {
                var diagonal = new StringBuilder();
                for (var j = 0; j < matrix.First().Count; j++)
                {
                    if (i + j < matrix.Count)
                    {
                        diagonal.Append(matrix[i + j][j]);
                    }
                }
                diagonals.Add(diagonal.ToString());
            }

            // down right diags middle up
            for (var i = 1; i < matrix.First().Count; i++)
            {
                var diagonal = new StringBuilder();
                for (var j = 0; j < matrix.Count; j++)
                {
                    if (i + j < matrix.First().Count)
                    {
                        diagonal.Append(matrix[j][i + j]);
                    }
                }
                diagonals.Add(diagonal.ToString());
            }

            // up right diags middle down
            for (var i = 0; i < matrix.Count; i++)
            {
                var diagonal = new StringBuilder();
                for (var j = 0; j < matrix.First().Count; j++)
                {
                    if (i - j >= 0)
                    {
                        diagonal.Append(matrix[i - j][j]);
                    }
                }
                diagonals.Add(diagonal.ToString());
            }

            // up right diags middle up
            for (var i = 1; i < matrix.First().Count; i++)
            {
                var diagonal = new StringBuilder();
                for (var j = 0; j < matrix.Count; j++)
                {
                    if (i + j < matrix.First().Count)
                    {
                        diagonal.Append(matrix[matrix.Count - 1 - j][i + j]);
                    }
                }
                diagonals.Add(diagonal.ToString());
            }

            var reverseDiagonals = new List<string>(diagonals.Count);
            foreach (var row in diagonals)
            {
                reverseDiagonals.Add(new string(row.Reverse().ToArray()));
            }

            var all = horizontals
                .Concat(reverseHorizontals)
                .Concat(verticals)
                .Concat(reverseVerticals)
                .Concat(diagonals)
                .Concat(reverseDiagonals)
                .ToList();

            var count = 0L;
            foreach (var line in all)
            {
                var matches = regex.Matches(line);
                count += matches.Count;
            }

            return count;
        }

        public long Part2(List<string> data)
        {
            throw new NotImplementedException();
        }

        [GeneratedRegex(@"XMAS")]
        private static partial Regex XmasRegex();
    }
}