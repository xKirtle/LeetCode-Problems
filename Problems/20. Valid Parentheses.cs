namespace LeetCode.Problems;

public class ValidParentheses : BaseProblem
{
    public ValidParentheses() => SetProblemStats(20, "Valid Parentheses", Difficulty.Easy);

    protected override void ActualExecuteTest()
    {
        //Example 1
        string str = "()";
        Console.WriteLine($"Example 1: {SolveValidParentheses(str)}");
        
        //Example 2
        str = "()[]{}";
        Console.WriteLine($"Example 2: {SolveValidParentheses(str)}");
        
        //Example 3
        str = "(]";
        Console.WriteLine($"Example 3: {SolveValidParentheses(str)}");
        
        //Example 4
        str = ")[](";
        Console.WriteLine($"Example 4: {SolveValidParentheses(str)}");
    }

    private bool SolveValidParentheses(string str)
    {
        Stack<int> stack = new Stack<int>();
        List<char> bracketChars = new List<char>() { '(', '[', '{', ')', ']', '}' };
        
        for (int i = 0; i < str.Length; i++)
        {
            int index = bracketChars.IndexOf(str[i]);
            bool openBracket = (index / 3) == 0;
            int bracketType =  index % 3; // 0 -> (), 1 -> [], 2 -> {}
            
            if (openBracket)
                stack.Push(bracketType);
            else if (stack.Count != 0 && stack.Peek() != bracketType)
                return false;
            else if (stack.Count == 0) //Starting with a closing bracket -> invalid
                return false;
            else
                stack.Pop();
        }
        
        return stack.Count == 0;
    }
}