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
    
    private static double MedianOfTwoSortedArrays(int[] nums1, int[] nums2)
    {
        int mergedLength = nums1.Length + nums2.Length;
        int[] newArr = new int[(mergedLength + 1 + (1 - mergedLength % 2)) / 2];

        int n1 = 0;
        int n2 = 0;
        for (int i = 0; i < newArr.Length; i++)
        {
            if (n1 >= nums1.Length || n2 >= nums2.Length)
                newArr[i] = n1 >= nums1.Length ? nums2[n2++] : nums1[n1++];
            else
                newArr[i] = nums1[n1] <= nums2[n2] ? nums1[n1++] : nums2[n2++];
        }

        return mergedLength % 2 != 0
            ? newArr[newArr.Length - 1]
            : (double) (newArr[newArr.Length - 2] + newArr[newArr.Length - 1]) / 2;
    }
}