namespace LeetCode.Problems;

public class ContainerWithMostWater : ITestable
{
    public int GetProblemNum() => 11;
    public Stats GetProblemStats() => new Stats("11. Container With Most Water", Difficulty.Medium, 224, 45.3);
    
    public void Test()
    {
        //Example 1
        int[] height = new[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
        Console.WriteLine($"Example 1: {SolveContainerWithMostWater(height)}");
        
        //Example 2
        height = new[] {1, 1};
        Console.WriteLine($"Example 2: {SolveContainerWithMostWater(height)}");
        
        //Example 3
        height = new[] {1, 2, 4, 3};
        Console.WriteLine($"Example 3: {SolveContainerWithMostWater(height)}");
        
        //Example 4
        height = new[] {1, 8, 6, 2, 5, 4, 8, 25, 7};
        Console.WriteLine($"Example 4: {SolveContainerWithMostWater(height)}");
    }

    private int SolveContainerWithMostWater(int[] height)
    {
        int start = 0, end = height.Length - 1, maxArea = 0;
        while (start <= end)
        {
            int area = Math.Min(height[start], height[end]) * (end - start);

            if (area > maxArea)
                maxArea = area;

            if (height[start] <= height[end])
                start++;
            else
                end--;
        }

        return maxArea;
    }
}