namespace LeetCode.Problems;

public class ThreeSum : BaseProblem
{
    public ThreeSum() => SetProblemStats(15, "Three Sum", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        int[] nums = { -1, 0, 1, 2, -1, -4 };
        IList<IList<int>> result = SolveThreeSum(nums);
        Console.WriteLine($"Example 1: {result.Count}");
        
        //Example 2
        nums = new int[] {0, 1, 1};
        result = SolveThreeSum(nums);
        Console.WriteLine($"Example 2: {result.Count}");
        
        //Example 3
        nums = new int[] { 0, 0, 0 };
        result = SolveThreeSum(nums);
        Console.WriteLine($"Example 3: {result.Count}");
        
        //Example 4
        nums = new int[] { 0, 0, 0, 0 };
        result = SolveThreeSum(nums);
        Console.WriteLine($"Example 4: {result.Count}");
    }

    private IList<IList<int>> SolveThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        int targetValue = 0;
        
        Array.Sort(nums);

        for (int left = 0; left < nums.Length - 2; left++)
        {
            //Since the array is sorted, we can't possibly sum three values to get our target when the first one is already above the target
            if (nums[left] > targetValue) 
                break;
            
            //Skip repeating numbers on our first pointer
            while (left > 0 && left + 1 < nums.Length && nums[left] == nums[left - 1]) left++;
            //Just make it continue if left > 0 && nums[left] == nums[left - 1] and let the for loop handle limits and incrementation?
            
            int middle = left + 1, right = nums.Length - 1;

            while (middle < right)
            {
                int sumValue = nums[left] + nums[middle] + nums[right];

                if (sumValue == targetValue)
                {
                    result.Add(new List<int>() {nums[left], nums[middle], nums[right]});
                    
                    //Skip over repeating numbers on our middle and last pointer
                    while (middle + 1 < nums.Length - 1 && nums[middle] == nums[middle + 1]) middle++;
                    while (right - 1 > 0 && nums[right] == nums[right - 1]) right--;

                    //Go to next position for each pointer
                    middle++;
                    right--;
                }
                else if (sumValue < targetValue)
                    middle++;
                else //if (sumValue > targetValue)
                    right--;
            }
        }

        return result;
    }
}