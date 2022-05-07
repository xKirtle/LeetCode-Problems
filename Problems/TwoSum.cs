public partial class Problems
{
    public static void TwoSumTest()
    {
        //Example 1
        int[] example1 = TwoSum(new[] {2, 7, 11, 15}, 9);
        Console.WriteLine($"Example 1: [{example1[0]}, {example1[1]}]");
        
        //Example 2
        int[] example2 = TwoSum(new[] {3, 2, 4}, 6);
        Console.WriteLine($"Example 2: [{example2[0]}, {example2[1]}]");
        
        //Example 3
        int[] example3 = TwoSum(new[] {3, 3}, 6);
        Console.WriteLine($"Example 3: [{example3[0]}, {example3[1]}]");
    }
    
    private static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(target - nums[i]))
                return new[] {dictionary[target - nums[i]], i};
            else
                dictionary.TryAdd(nums[i], i);
        }

        return null;
    }
}