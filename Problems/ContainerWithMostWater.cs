namespace LeetCode.Problems;

public class ContainerWithMostWater : ITestable
{
    public int GetProblemNum() => 11;
    public Stats GetProblemStats() => new Stats("11. Container With Most Water", Difficulty.Medium, -1, -1);
    
    public void Test()
    {
        Console.WriteLine(GetProblemStats().ToString());
        
        //Example 1 -> 49
        int[] height = new[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
        Console.WriteLine($"Example 1: {SolveContainerWithMostWater(height)}");
        
        //Example 2 -> 1
        height = new[] {1, 1};
        Console.WriteLine($"Example 2: {SolveContainerWithMostWater(height)}");
    }

    private int SolveContainerWithMostWater(int[] height)
    {
        

        return 0;
    }
}