class solution
{
    static void Main()
    {
        string currentDirectory = Environment.CurrentDirectory;
        string? projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;
        if (projectDirectory is null) return;
        string input = System.IO.File.ReadAllText(projectDirectory + "/input.txt");
        
        Console.Write(input);
        
        Console.WriteLine("\n\nSolution 1 answer: " + solution_1());
        Console.WriteLine("\nSolution 2 answer: " + solution_2());
    }

    static object solution_1()
    {
        return "none";
    }

    static object solution_2()
    {
        return "none";
    }
}