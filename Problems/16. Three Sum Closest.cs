namespace LeetCode.Problems;

public class ThreeSumClosest : BaseProblem
{
    public ThreeSumClosest() => SetProblemStats(16, "Three Sum Closest", Difficulty.Medium);

    protected override void ActualExecuteTest() 
    {
        //Example 1
        int[] arr = new[] { -1, 2, 1, -4 };
        int target = 1;
        Console.WriteLine($"Example 1: {SolveThreeSumClosest(arr, target)}");
        
        //Example 2
        arr = new[] { 0, 0, 0 };
        target = 1;
        Console.WriteLine($"Example 2: {SolveThreeSumClosest(arr, target)}");
    }

    private int SolveThreeSumClosest(int[] arr, int target)
    {
        if (arr.Length == 3)
            return arr[0] + arr[1] + arr[2];
        
        Array.Sort(arr);
        int closestResult = int.MaxValue;

        for (int i = 0; i < arr.Length - 2; i++)
        {
            int left = i + 1;
            int right = arr.Length - 1;

            while (left < right)
            {
                int sum = arr[i] + arr[left] + arr[right];

                if (sum == target)
                    return sum;

                if (Math.Abs(sum - target) < Math.Abs(closestResult - target))
                    closestResult = sum;
                
                if (sum > target)
                    right--;
                else if (sum < target)
                    left++;
            }
        }
        
        return closestResult;
    }
}