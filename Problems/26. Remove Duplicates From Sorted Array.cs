namespace LeetCode.Problems;

public class RemoveDuplicatesFromSortedArray : BaseProblem
{
    public RemoveDuplicatesFromSortedArray() => SetProblemStats(26, "Remove Duplicates From Sorted Array", Difficulty.Easy);

    protected override void ActualExecuteTest()
    {
        //Example 1
        int[] nums = new int[] { 1, 1, 2 };
        Console.WriteLine($"Example 1: {RemoveDuplicates(nums)}");
        
        //Example 2
        nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        Console.WriteLine($"Example 2: {RemoveDuplicates(nums)}");
        
        //Example 3
        nums = new int[] { 1, 1 };
        Console.WriteLine($"Example 3: {RemoveDuplicates(nums)}");
    }

    private int RemoveDuplicates(int[] nums)
    {
        int count = 1;

        if (nums.Length == 2 && nums[0] == nums[1])
            return count;

        for (int i = 1; i < nums.Length; i++)
        {
            while (i < nums.Length && nums[i] == nums[i - 1]) i++;
            
            if (count < nums.Length && i < nums.Length)
                nums[count++] = nums[i];
        }
        
        return count;
    }
}