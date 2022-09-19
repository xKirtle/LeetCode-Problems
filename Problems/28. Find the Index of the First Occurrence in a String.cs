namespace LeetCode.Problems;

public class FindTheIndexOfTheFirstOccurenceInString : BaseProblem
{
    public FindTheIndexOfTheFirstOccurenceInString() => SetProblemStats(28, "Find the Index of the First Occurrence in a String", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1 
        string haystack = "sadbutsad";
        string needle = "sad";
        Console.WriteLine($"Example 1: {SolveFindIndexOfTheFirstOccurenceInString(haystack, needle)}");
        
        //Example 2
        haystack = "leetcode";
        needle = "leeto";
        Console.WriteLine($"Example 2: {SolveFindIndexOfTheFirstOccurenceInString(haystack, needle)}");
        
        //Example 3
        haystack = "mississippi";
        needle = "issip";
        Console.WriteLine($"Example 3: {SolveFindIndexOfTheFirstOccurenceInString(haystack, needle)}");
    }

    private int SolveFindIndexOfTheFirstOccurenceInString(string haystack, string needle)
    {
        //TODO: Check https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
        
        if (String.IsNullOrEmpty(needle) || haystack == needle) return 0;
        if (haystack.Length < needle.Length) return -1;

        for (int i = 0; i < haystack.Length - needle.Length + 1; i++) //Iterate haystack until remaining string is smaller than needle
        {
            if (haystack[i] == needle[0]) //If first character matches, attempt to match rest of the needle
            {
                for (int j = 0; j < needle.Length; j++)
                {
                    if (needle[j] != haystack[i + j]) //if !=, attempt to find another first char match
                        break;
                    else if (j == needle.Length - 1) //Matched the entire needle
                        return i;
                }
            }
        }

        return -1;
    }
}