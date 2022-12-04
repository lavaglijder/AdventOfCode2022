public class Solution
{
    static void Main()
    {
        string currentDirectory = Environment.CurrentDirectory;
        string? projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;
        if (projectDirectory is null) return;
        string input = File.ReadAllText(projectDirectory + "/input.txt");

        Console.WriteLine("\n\nSolution 1 answer: " + solution_1(input));
        Console.WriteLine("\nSolution 2 answer: " + solution_2(input));
    }

    public static bool isOneWithinRange(string[] strs)
    {
        string[] numberRange1 = strs[0].Split("-");
        string[] numberRange2 = strs[1].Split("-");


        if (int.Parse(numberRange1[0]) <= int.Parse(numberRange2[0]) &&
            int.Parse(numberRange1[1]) >= int.Parse(numberRange2[1]))
        {
            return true;
        }

        if (int.Parse(numberRange2[0]) <= int.Parse(numberRange1[0]) &&
            int.Parse(numberRange2[1]) >= int.Parse(numberRange1[1]))
        {
            return true;
        }

        return false;
    }

    public static bool Overlaps(string[] strs)
    {
        string[] numberRange1 = strs[0].Split("-");
        string[] numberRange2 = strs[1].Split("-");

        int min = Math.Min(int.Parse(numberRange1[1]), int.Parse(numberRange2[1]));
        int max = Math.Max(int.Parse(numberRange1[0]), int.Parse(numberRange2[0]));
        
        return min >= max;
    }

    public static object solution_1(string input)
    {
        string[] lines = input.Split("\n");
        int total = 0;
        foreach (string line in lines)
        {
            string[] numberRanges = line.Split(",");

            if (isOneWithinRange(numberRanges)) total += 1;
        }
        return total;
    }

    public static object solution_2(string input)
    {
        string[] lines = input.Split("\n");
        int total = 0;
        foreach (string line in lines)
        {
            string[] numberRanges = line.Split(",");

            if (Overlaps(numberRanges)) total += 1;
        }
        return total;
    }
}