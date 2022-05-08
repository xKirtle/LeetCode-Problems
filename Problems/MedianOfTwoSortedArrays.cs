public partial class Problems
{
    public static void MedianOfTwoSortedArraysTest()
    {
        //Example 1
        int[] nums1 = new[] {1, 3};
        int[] nums2 = new[] {2};
        Console.WriteLine($"Example 1: {MedianOfTwoSortedArrays(nums1, nums2)}");
        
        //Example 2
        nums1 = new[] {1, 2};
        nums2 = new[] {3, 4};
        Console.WriteLine($"Example 2: {MedianOfTwoSortedArrays(nums1, nums2)}");
    }

    //Slow.. Could try using a Binary Search algorithm?..
    private static double MedianOfTwoSortedArrays(int[] nums1, int[] nums2)
    {
        int[] newArr = nums1.Concat(nums2).ToArray();
        Array.Sort(newArr);
        bool singleDigitMedian = newArr.Length % 2 != 0;
        int medianIndex = newArr.Length / 2;

        return singleDigitMedian ? newArr[medianIndex] : (double)(newArr[medianIndex - 1] + newArr[medianIndex]) / 2;
    }
}