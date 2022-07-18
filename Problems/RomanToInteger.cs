namespace LeetCode.Problems;

public class RomanToInteger : BaseProblem
{
    public RomanToInteger() => SetProblemStats(13, "Roman To Integer", Difficulty.Easy);
    
    protected override void ActualExecuteTest()
    {
        //Example 1
        string str = "III";
        Console.WriteLine($"Example 1: {SolveRomanToInteger(str)}");
        
        //Example 2
        str = "LVIII";
        Console.WriteLine($"Example 2: {SolveRomanToInteger(str)}");
        
        //Example 3
        str = "MCMXCIV";
        Console.WriteLine($"Example 3: {SolveRomanToInteger(str)}");
    }

    // private int SolveRomanToInteger(string str)
    // {
    //     int result = 0;
    //     for (int i = 0; i < str.Length; i++)
    //     {
    //         if (i < str.Length - 1 && 
    //             ((str[i] == 'I' && (str[i + 1] == 'V' || str[i + 1] == 'X')) ||
    //             (str[i] == 'X' && (str[i + 1] == 'L' || str[i + 1] == 'C')) ||
    //             (str[i] == 'C' && (str[i + 1] == 'D' || str[i + 1] == 'M'))))
    //         {
    //             if (Roman.TryParse($"{str[i]}{str[i + 1]}", out Roman roman))
    //             {
    //                 result += (int) roman;
    //                 i += 1;
    //             }
    //         }
    //         else if (Roman.TryParse(str[i].ToString(), out Roman roman))
    //             result += (int) roman;
    //     }
    //
    //     return result;
    // }
    //
    // //Could shave off some time by using a switch to assign a value to each char combination
    // private enum Roman : int
    // {
    //     I = 1,
    //     IV = 4,
    //     V = 5,
    //     IX = 9,
    //     X = 10,
    //     XL = 40,
    //     L = 50,
    //     XC = 90,
    //     C = 100,
    //     CD = 400,
    //     D = 500,
    //     CM = 900,
    //     M = 1000
    // }

    //Somewhat faster than enum try parsing
    private int SolveRomanToInteger(string str)
    {
        int result = 0;
        for (int i = 0; i < str.Length; i++)
        {
            int currentValue = CharToInteger(str[i]);
            if (i < str.Length - 1 && CharToInteger(str[i + 1]) > currentValue)
                result -= currentValue;
            else
                result += currentValue;
        }
        
        return result;
    }

    private int CharToInteger(char c)
    {
        int value = 0;
        switch (c)
        {
            case 'I': value = 1;
                break;
            case 'V': value = 5;
                break;
            case 'X': value = 10;
                break;
            case 'L': value = 50;
                break;
            case 'C': value = 100;
                break;
            case 'D': value = 500;
                break;
            case 'M': value = 1000;
                break;
        }

        return value;
    }
}