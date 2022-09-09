namespace LeetCode.Problems;

public class GenerateParentheses : BaseProblem
{
    public GenerateParentheses() => SetProblemStats(22, "Generate Parentheses", Difficulty.Medium);

    protected override void ActualExecuteTest()
    {
        //Example 1
        int n = 3;
        Console.WriteLine($"Example 1: {String.Join(", ", SolveGenerateParentheses(n))}");
        
        //Example 2
        n = 1;
        Console.WriteLine($"Example 2: {String.Join(", ", SolveGenerateParentheses(n))}");
    }

    private IList<string> SolveGenerateParentheses(int n)
    {
        List<string> list = new List<string>();
        BacktrackingSolution(list, String.Empty, 0, 0, n);

        return list;
    }

    private void BacktrackingSolution(List<string> list, string str, int openBrackets, int closedBrackets, int maxBracketPairs)
    {
        if (str.Length == maxBracketPairs * 2)
        {
            list.Add(str);
            return;
        }
        
        if (openBrackets < maxBracketPairs)
            BacktrackingSolution(list, str + "(", openBrackets + 1, closedBrackets, maxBracketPairs);
        
        if (closedBrackets < openBrackets)
            BacktrackingSolution(list, str + ")", openBrackets, closedBrackets + 1, maxBracketPairs);
    }
}