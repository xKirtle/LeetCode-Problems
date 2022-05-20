namespace LeetCode.Problems;

public class ReverseInteger : ITestable
{
    public int GetProblemNum() => 7;
    public Stats GetProblemStats() => new Stats("7. Reverse Integer", Difficulty.Medium, 27, 25.6);

    public void Test()
    {
        Console.WriteLine(GetProblemStats().ToString());
        
        //Example 1
        int x = 123;
        Console.WriteLine($"Example 1: {SolveReverseInteger(x)}");

        //Example 2
        x = -123;
        Console.WriteLine($"Example 2: {SolveReverseInteger(x)}");

        //Example 3
        x = 120;
        Console.WriteLine($"Example 3: {SolveReverseInteger(x)}");
    }

    private int SolveReverseInteger(int x)
    {
        //Checking if str[0] == '-' and replacing it out is faster than this logic below..
        string str = x < 0 ? (x * -1).ToString() : x.ToString();

        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        string reversedInt = (x < 0 ? "-" : "") + new string(arr);

        return int.TryParse(reversedInt, out int parsedValue) ? parsedValue : 0;
    }
}