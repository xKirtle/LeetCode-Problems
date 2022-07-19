using System.Text;

namespace LeetCode;

public class LongestCommonPrefix : BaseProblem
{
    public LongestCommonPrefix() => SetProblemStats(14, "Longest Common Prefix", Difficulty.Easy);

    protected override void ActualExecuteTest() 
    {
        //Example 1
        string[] arr = new[] {"flower", "flow", "flight"};
        Console.WriteLine($"Example 1: {SolveLongestCommonPrefix(arr)}");

        //Example 2
        arr = new[] {"dog", "racecar", "car"};
        Console.WriteLine($"Example 2: {SolveLongestCommonPrefix(arr)}");
    }

    private string SolveLongestCommonPrefix(string[] arr) 
    {
        string prefix = arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int charIndex = 0;
            while (charIndex < Math.Min(arr[i].Length, arr[i + 1].Length) && arr[i][charIndex] == arr[i + 1][charIndex])
                charIndex++;

            if (prefix.Length <= charIndex - 1) continue;
            
            prefix = prefix.Substring(0, charIndex);
            if (string.IsNullOrEmpty(prefix))
                return prefix;
        }
        
        return prefix;
    }
}