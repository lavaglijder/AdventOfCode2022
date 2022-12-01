using System.Collections;

class solution
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

    static object solution_1(string input)
    {
        String[] lines = input.Split("\n");
        int maxCalories = 0;
        int currentCalories = 0;
        
        for (var i = 0; i < lines.Length; i++)
        {
            string currentLine = lines[i];
            currentLine = currentLine.Trim();
            if (currentLine == "")
            {
                maxCalories = Math.Max(maxCalories, currentCalories);
                currentCalories = 0;
            }
            else
            {
                currentCalories += Int32.Parse(currentLine);
            }
        }
        maxCalories = Math.Max(maxCalories, currentCalories);
        
        return maxCalories;
    }

    static object solution_2(string input)
    {
        String[] lines = input.Split("\n");
        List<int> caloriesList = new List<int>();
        int currentCalories = 0;
        
        for (var i = 0; i < lines.Length; i++)
        {
            string currentLine = lines[i];
            currentLine = currentLine.Trim();
            if (currentLine == "")
            {
                caloriesList.Add(currentCalories);
                currentCalories = 0;
            }
            else
            {
                currentCalories += Int32.Parse(currentLine);
            }
        }
        caloriesList.Add(currentCalories);

        caloriesList.Sort();
        
        return caloriesList.GetRange(caloriesList.Count - 3, 3).Sum();
    }
}