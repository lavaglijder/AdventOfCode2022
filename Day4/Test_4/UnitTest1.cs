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
    public void TestWithinRange()
    {
        Assert.That(Solution.isOneWithinRange(new []{"2-4", "6-8"}), Is.EqualTo(false));
        Console.WriteLine("\n\n1");
        Assert.That(Solution.isOneWithinRange(new []{"2-6", "4-8"}), Is.EqualTo(false));
        Console.WriteLine("\n\n2");
        
        Assert.That(Solution.isOneWithinRange(new []{"6-8", "2-4"}), Is.EqualTo(false));
        Console.WriteLine("\n\n3");
        Assert.That(Solution.isOneWithinRange(new []{"4-8", "2-6"}), Is.EqualTo(false));
        Console.WriteLine("\n\n4");
        
        Assert.That(Solution.isOneWithinRange(new []{"6-6", "4-6"}), Is.EqualTo(true)); 
        Console.WriteLine("\n\n5");   
        Assert.That(Solution.isOneWithinRange(new []{"2-8", "3-7"}), Is.EqualTo(true));  
        Console.WriteLine("\n\n6");  
        
        Assert.That(Solution.isOneWithinRange(new []{"4-6", "6-6"}), Is.EqualTo(true)); 
        Console.WriteLine("\n\n7");   
        Assert.That(Solution.isOneWithinRange(new []{"3-7","2-8"}), Is.EqualTo(true));  
        Console.WriteLine("\n\n8");  
    }

    [Test]
    public void TestOverlaps()
    {
        Console.WriteLine("\n\n1");
        Assert.That(Solution.Overlaps(new []{"2-4", "6-8"}), Is.EqualTo(false));
        Console.WriteLine("\n\n2");
        Assert.That(Solution.Overlaps(new []{"2-6", "4-8"}), Is.EqualTo(true));

        Console.WriteLine("\n\n3");
        Assert.That(Solution.Overlaps(new []{"6-8", "2-4"}), Is.EqualTo(false));
        Console.WriteLine("\n\n4");
        Assert.That(Solution.Overlaps(new []{"4-8", "2-6"}), Is.EqualTo(true));

        Console.WriteLine("\n\n5");
        Assert.That(Solution.Overlaps(new []{"6-6", "4-6"}), Is.EqualTo(true));
        Console.WriteLine("\n\n6");
        Assert.That(Solution.Overlaps(new []{"2-8", "3-7"}), Is.EqualTo(true));

        Console.WriteLine("\n\n7");
        Assert.That(Solution.Overlaps(new []{"4-6", "6-6"}), Is.EqualTo(true));
        Console.WriteLine("\n\n8");
        Assert.That(Solution.Overlaps(new []{"3-7","2-8"}), Is.EqualTo(true));
    }

    [Test]
    public void TestSolution1()
    {
        Assert.That(Solution.solution_1(testInput), Is.EqualTo(2));
    }

    [Test]
    public void TestSolution2()
    {
        Assert.That(Solution.solution_2(testInput), Is.EqualTo(4));
    } 
}