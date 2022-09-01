namespace LeetCode.Problems;

public class LetterCombinationsOfAPhoneNumber : BaseProblem
{
    public LetterCombinationsOfAPhoneNumber()
        => SetProblemStats(17, "Letter Combinations Of A Phone Number", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        string digits = "23";
        Console.WriteLine($"Example 1: {SolveLetterCombinationsOfAPhoneNumber(digits)}");
        
        //Example 2
        digits = "";
        Console.WriteLine($"Example 2: {SolveLetterCombinationsOfAPhoneNumber(digits)}");
        
        //Example 3
        digits = "2";
        Console.WriteLine($"Example 3: {SolveLetterCombinationsOfAPhoneNumber(digits)}");
    }

    private static Dictionary<int, string> mappings = new() 
    {
        {2, "abc"}, {3, "def"}, {4, "ghi"},
        {5, "jkl"}, {6, "mno"}, {7, "pqrs"},
        {8, "tuv"}, {9, "wxyz"}
    };
    private List<string> SolveLetterCombinationsOfAPhoneNumber(string digits)
    {
        List<string> result = new();

        if (string.IsNullOrEmpty(digits))
            return result;
        
        int numDigits = digits.ToString().Length;

        void RecursiveSolution(int digitIndex, string curString)
        {
            if (digitIndex == numDigits)
            {
                result.Add(curString);
                return;
            }
            
            int digit = int.Parse(digits[digitIndex].ToString());
            foreach (char c in mappings[digit])
                RecursiveSolution(digitIndex + 1, curString + c);
        }
        
        RecursiveSolution(0, "");
        return result;
    }
}