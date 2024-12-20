﻿using System.Reflection;

var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
var dataPath = Path.Combine(workingDirectory.FullName, "Data");

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes().Where(t => t.Namespace == "AdventOfCode2024");
foreach (var type in types)
{
    if (type.GetInterface("IDay") != null)
    {
        var filePath = Path.Combine(dataPath, $"{type.Name}.txt");
        using var fileStream = File.OpenRead(filePath);
        using var streamReader = new StreamReader(fileStream);

        var data = new List<string>();
        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            data.Add(line);
        }

        var instance = Activator.CreateInstance(type);

        var part1 = type.GetMethod("Part1");
        var part2 = type.GetMethod("Part2");

        try
        {
            long part1Result = (long)(part1?.Invoke(instance, [data]) ?? 0L);
            Console.WriteLine($"{type.Name} Part1: {part1Result}");
        }
        catch (TargetInvocationException ex)
        {
            if (ex.InnerException is NotImplementedException)
            {
                Console.WriteLine($"{type.Name} Part1:");
            }
            else
            {
                throw;
            }
        }

        try
        {
            long part2Result = (long)(part2?.Invoke(instance, [data]) ?? 0L);
            Console.WriteLine($"{type.Name} Part2: {part2Result}");
        }
        catch (TargetInvocationException ex)
        {
            if (ex.InnerException is NotImplementedException)
            {
                Console.WriteLine($"{type.Name} Part2:");
            }
            else
            {
                throw;
            }
        }

        Console.WriteLine();
    }
}