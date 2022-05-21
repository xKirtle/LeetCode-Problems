namespace LeetCode.Problems;

public class LongestSubstringWithoutRepeatingCharacters : ITestable
{
    public int GetProblemNum() => 3;

    public Stats GetProblemStats() =>
        new Stats("3. Longest Substring Without Repeating Characters", Difficulty.Medium, 78, 37);
    
    public void Test()
    {
        //Example 1
        string str = "abcabcbb";
        Console.WriteLine($"Example 1: {SolveLongestSubstringWithoutRepeatingCharacters(str)}");
        
        //Example 2
        str = "bbbbb";
        Console.WriteLine($"Example 2: {SolveLongestSubstringWithoutRepeatingCharacters(str)}");  
        
        //Example 3
        str = "pwwkew";
        Console.WriteLine($"Example 3: {SolveLongestSubstringWithoutRepeatingCharacters(str)}");
    }
    
    private int SolveLongestSubstringWithoutRepeatingCharacters(string s)
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