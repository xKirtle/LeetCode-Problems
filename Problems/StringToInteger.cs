namespace LeetCode.Problems;

public class StringToInteger : ITestable
{
    public int GetProblemNum() => 8;

    public void Test()
    {

        Console.WriteLine($"{SolveStringToInteger(" ")}");
        //Example 1 -> 42
        string s = "42";
        Console.WriteLine($"Example 1: {SolveStringToInteger(s)}");
        
        //Example 2 -> -42
        s = "   -42";
        Console.WriteLine($"Example 2: {SolveStringToInteger(s)}");
        
        //Example 3 -> 4193
        s = "4193 with words";
        Console.WriteLine($"Example 3: {SolveStringToInteger(s)}");
        
        //My own test cases
        
        //Example 4 -> 32
        s = "000032";
        Console.WriteLine($"Example 4: {SolveStringToInteger(s)}");
        
        //Example 5 -> 7684
        s = "words before 7684";
        Console.WriteLine($"Example 5: {SolveStringToInteger(s)}");
    }

    private int SolveStringToInteger(string s)
    {
        int sign = 1, Base = 0, i = 0;

        if (string.IsNullOrWhiteSpace(s)) return 0;
        
        //Remove whitespaces
        while (s[i] == ' ') i++;

        //negative/positive signs
        if (s[i] == '-' || s[i] == '+')
            sign = 1 - 2 * (s[i++] == '-' ? 1 : 0);
        
        
        //Check if input is valid (digits)
        while (i < s.Length && char.IsDigit(s[i]))
        {
            //Checking for overflow
            if (Base > int.MaxValue / 10 || (Base == int.MaxValue / 10 && s[i] - '0' > 7))
                return sign == 1 ? int.MaxValue : int.MinValue;

            Base = 10 * Base + (s[i++] - '0');
        }
        
        return Base * sign;
    }
}