public partial class Problems
{
    public static void LongestPalindromicSubstringTest()
    {
        //Example 1
        string s = "babad";
        Console.WriteLine(LongestPalindromicSubstring(s));
        
        //Example 2
        s = "cbbd";
        Console.WriteLine(LongestPalindromicSubstring(s));
    }

    private static string LongestPalindromicSubstring(string s)
    {
        if (s.Length < 2)
            return s.Length == 1 ? s[0].ToString() : "";

        string result = "";
        int low, high;
        for (int i = 0; i < s.Length; i++)
        {
            low = i - 1;
            high = i + 1;

            //For when the word has two middle equal letters -> abba
            while (high < s.Length && s[high] == s[i]) high++;
            while (low >= 0 && s[low] == s[i]) low--;

            //Go both directions until chars are no longer the same
            while (low >= 0 && high < s.Length && s[low] == s[high])
            {
                low--;
                high++;
            }

            //Get word from our low/high pointers
            int wordLength = high - low - 1;
            if (result.Length < wordLength)
                result = s.Substring(low + 1, wordLength);
        }

        return result;
    }
}