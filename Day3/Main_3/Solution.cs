using System.Text.RegularExpressions;

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

    public static string[] SplitString(string str)
    {
        int mid = (int)Math.Floor(str.Length / 2d);
        return new[] { str.Substring(0, mid), str.Substring(mid, str.Length - mid) };
    }

    private static int getPriority(char c)
    {
        int placeInAlphabet = c.ToString().ToUpper().ToCharArray()[0] - 64;
        if (new Regex(@"[A-Z]").IsMatch(c.ToString())) placeInAlphabet += 26;
        return placeInAlphabet;
    }

    public static object solution_1(string input)
    {
        string[] rows = input.Split("\n");
        int total = 0;
        foreach (string row in rows)
        {
            int priority = 0;
            string[] splitted = SplitString(row);
            foreach (char c in splitted[0])
            {
                int placeInAlphabet = getPriority(c);
                if (splitted[1].Contains(c)) priority = Math.Max(priority, placeInAlphabet);
            }

            total += priority;
        }
        return total;
    }
    public static object solution_2(string input)
    {
        string[] rows = input.Split("\n");
        int total = 0;
        for (int i = 0; i < rows.Length/3; i++)
        {
            string line1 = rows[i * 3].Trim();
            string line2 = rows[i * 3 + 1].Trim();
            string line3 = rows[i * 3 + 2].Trim();
            
            Dictionary<char, int> foundAmount = new Dictionary<char, int>();

            void CheckLine(string line)
            {
                List<char> alreadyChecked = new List<char>();
                foreach (char c in line)
                {
                    if (alreadyChecked.Contains(c)) continue;
                    int currentAmount = foundAmount.GetValueOrDefault(c, 0);
                    foundAmount.Remove(c);
                    foundAmount.Add(c, currentAmount + 1);
                    alreadyChecked.Add(c);
                }
            }

            CheckLine(line1);
            CheckLine(line2);
            CheckLine(line3);

            int priority = foundAmount.Max(pair =>
            {
                if (pair.Value < 3) return 0;
                return getPriority(pair.Key);
            });

            
            total += priority;
        }
        return total;
    }
}