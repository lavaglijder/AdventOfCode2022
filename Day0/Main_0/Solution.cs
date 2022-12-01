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

    public static object solution_1(string input)
    {
        return "none";
    }

    public static object solution_2(string input)
    {
        return "none";
    }
}