namespace LeetCode.Problems;

public class IntegerToRoman : BaseProblem
{
    public IntegerToRoman() => SetProblemStats(12, "Integer To Roman", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        int num = 3;
        Console.WriteLine($"Example 1: {SolveIntegerToRoman(num)}");

        //Example 2
        num = 58;
        Console.WriteLine($"Example 2: {SolveIntegerToRoman(num)}");
        
        //Example 3
        num = 1994;
        Console.WriteLine($"Example 3: {SolveIntegerToRoman(num)}");
    }

    private readonly static Roman[] roman = new[]
    {
        Roman.M, Roman.CM, Roman.D, Roman.CD, Roman.C, Roman.XC,
        Roman.L, Roman.XL, Roman.X, Roman.IX, Roman.V, Roman.IV, Roman.I
    };
    private string SolveIntegerToRoman(int num)
    {
        if (num == 0)
            return "";
        
        Roman biggestDivider = BiggestDivider(num);
        return biggestDivider.ToString() + SolveIntegerToRoman(num - (int) biggestDivider);
    }

    private Roman BiggestDivider(int num)
    {
        for (int i = 0; i < roman.Length; i++)
            if (num / (int) roman[i] != 0)
                return roman[i];

        return Roman.I;
    }

    private enum Roman : int
    {
        I = 1,
        IV = 4,
        V = 5,
        IX = 9,
        X = 10,
        XL = 40,
        L = 50,
        XC = 90,
        C = 100,
        CD = 400,
        D = 500,
        CM = 900,
        M = 1000
    }
}