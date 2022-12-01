namespace Test;



public class Tests
{
    private string testInput;
    [SetUp]
    public void Setup()
    {
        string currentDirectory = Environment.CurrentDirectory;
        string? projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;
        if (projectDirectory is null) return;
        testInput = File.ReadAllText(projectDirectory + "/input.txt");
    }

    [Test]
    public void Test_Solutions()
    {
        Assert.That(Solution.solution_1(testInput), Is.EqualTo(24000));
        Assert.That(Solution.solution_2(testInput), Is.EqualTo(45000));
    }
}