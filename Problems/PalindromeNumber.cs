public partial class Problems
{
    public static void PalindromeNumberTest()
    {
        //Example 1
        int x = 121;
        Console.WriteLine($"Example 1: {PalindromeNumber(x)}");
        
        //Example 2
        x = -121;
        Console.WriteLine($"Example 2: {PalindromeNumber(x)}");
        
        //Example 3
        x = 10;
        Console.WriteLine($"Example 3: {PalindromeNumber(x)}");
    }

    private static bool PalindromeNumber(int x)
    {
        string str = x.ToString();
        int middle1 = (int)((double)str.Length / 2 - (str.Length % 2 != 0 ? 0 : 1));
        int middle2 = middle1 + (str.Length % 2 != 0 ? 0 : 1);

        while (middle1 > 0 && middle2 < str.Length && str[middle1] == str[middle2])
        {
            middle1--;
            middle2++;
        }

        return middle1 == 0 && middle2 == str.Length - 1 && str[middle1] == str[middle2];
    }
}