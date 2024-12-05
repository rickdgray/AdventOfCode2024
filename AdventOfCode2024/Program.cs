using System.Reflection;

var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
var path = Path.Combine(workingDirectory?.Parent?.Parent?.Parent?.FullName
    ?? throw new DirectoryNotFoundException(), "Data", "Day01.txt");
using var fileStream = File.OpenRead(path);
using var streamReader = new StreamReader(fileStream);

var data = new List<string>();
string? line;
while ((line = streamReader.ReadLine()) != null)
{
    data.Add(line);
}

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes().Where(t => t.Namespace == "AdventOfCode2024");
foreach (var type in types)
{
    if (type.GetInterface("IDay") != null)
    {
        var instance = Activator.CreateInstance(type);

        var part1 = type.GetMethod("Part1");
        var part2 = type.GetMethod("Part2");

        try
        {
            long part1Result = (long)(part1?.Invoke(instance, [data]) ?? 0L);
            Console.WriteLine($"{type.Name} Part1: {part1Result}");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine($"{type.Name} Part1:");
        }

        try
        {
            long part2Result = (long)(part2?.Invoke(instance, [data]) ?? 0L);
            Console.WriteLine($"{type.Name} Part2: {part2Result}");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine($"{type.Name} Part2:");
        }
    }
}