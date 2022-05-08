public partial class Problems
{
    public static void LongestSubstringWithoutRepeatingCharactersTest()
    {
        //Example 1
        string str = "abcabcbb";
        Console.WriteLine($"Example 1: {LongestSubstringWithoutRepeatingCharacters(str)}");
        
        //Example 2
        str = "bbbbb";
        Console.WriteLine($"Example 2: {LongestSubstringWithoutRepeatingCharacters(str)}");  
        
        //Example 3
        str = "pwwkew";
        Console.WriteLine($"Example 3: {LongestSubstringWithoutRepeatingCharacters(str)}");
    }
    
    private static int LongestSubstringWithoutRepeatingCharacters(string s)
    {
        int start = 0;
        int result = 0;
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        for (int end = 0; end < s.Length; end++)
        {
            if (dictionary.TryGetValue(s[end], out int duplicateIndex))
            {
                result = Math.Max(result, end - start);

                for (int i = start; i <= duplicateIndex; i++)
                    dictionary.Remove(s[i]);
                
                start = duplicateIndex + 1;
            }

            dictionary.Add(s[end], end);
        }

        return Math.Max(result, s.Length - start);
    }
}