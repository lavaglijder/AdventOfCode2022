using System.Drawing;
using System.Linq.Expressions;

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
        // Rock paper scissors
        // A => Rock, B =>Paper, C => Scissors
        string[] lines = input.Split("\n");
        int total = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] chosen = line.Split(" ");
            
            // Convert my choice to the first choice and add points accordingly
            string myChoice;
            switch (chosen[1].Trim())
            {
                case "X":
                    myChoice = "A";
                    total += 1;
                    break;
                case "Y":
                    myChoice = "B";
                    total += 2;
                    break;
                default:
                    myChoice = "C";
                    total += 3;
                    break;
            }
            
            // Add 3 if draw
            if (chosen[0].Trim() == myChoice)
            {
                total += 3;
                continue;
            }
            
            // Choice first, Winner second
            string[][] winners =  {new []{"A", "B"},new []{"B", "C"},new []{"C", "A"}};

            // Add 6 if win
            foreach (string[] winner in winners)
            {
                if(winner[0] != chosen[0].Trim()) continue;
                if (myChoice != winner[1]) continue;
                total += 6;
            }
        }
        return total;
    }

    public static object solution_2(string input)
    {
        string[] lines = input.Split("\n");
        int total = 0;

        // {Chosen by enemy, {Winner choice, Loser choice}}
        Dictionary<string, string[]> winners = new Dictionary<string, string[]>
            {{"A", new []{"B", "C"}}, {"B", new []{"C", "A"}}, {"C", new []{"A", "B"}}};
        
        // Amount of points given when chosen x
        Dictionary<string, int> points = new Dictionary<string, int>
            {{"A", 1}, {"B", 2}, {"C", 3}};
        
        for (var i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] chosen = line.Split(" ");

            string trim = chosen[0].Trim();
            string[]? winLoseChoice = winners.GetValueOrDefault(trim);
            if(winLoseChoice == null) throw new ArgumentException("Weird " + trim + " is not found");
            
            // X = lose, Y = draw, Z = win
            switch (chosen[1].Trim())
            {
                case "X":
                    total += points.GetValueOrDefault(winLoseChoice[1]);
                    break;
                case "Y":
                    total += 3;
                    total += points.GetValueOrDefault(trim);
                    break;
                case "Z":
                    total += 6;
                    total += points.GetValueOrDefault(winLoseChoice[0]);
                    break;
            }
            
        }
        return total;
    }
}