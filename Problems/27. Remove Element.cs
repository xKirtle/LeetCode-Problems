namespace LeetCode.Problems;

public class RemoveElement : BaseProblem
{
    public RemoveElement() => SetProblemStats(27, "Remove Element", Difficulty.Easy);

    protected override void ActualExecuteTest()
    {
        //Example 1
        int[] nums = new[] { 3, 2, 2, 3 };
        int value = 3;
        Console.WriteLine($"Example 1: {SolveRemoveElement(nums, value)}");
        
        //Example 2
        nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
        value = 2;
        Console.WriteLine($"Example 2: {SolveRemoveElement(nums, value)}");
    }

    private int SolveRemoveElement(int[] nums, int value)
    {
        int left = 0;

        for (int i = 0; i < nums.Length; i++)
            if (nums[i] != value)
                nums[left++] = nums[i];
        
        return left;
    }
}