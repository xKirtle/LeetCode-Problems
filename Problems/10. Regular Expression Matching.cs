namespace LeetCode.Problems;

public class RegularExpressionMatching : BaseProblem
{
    public RegularExpressionMatching() => SetProblemStats(10, "Regular Expression Matching", Difficulty.Hard);
    
    protected override void ActualExecuteTest()
    {
        //Example 1
        string str = "aa";
        string pattern = "a";
        Console.WriteLine($"Example 1: {SolveRegularExpressionMatching(str, pattern)}");
        
        //Example 2
        str = "aa";
        pattern = "a*";
        Console.WriteLine($"Example 2: {SolveRegularExpressionMatching(str, pattern)}");
        
        //Example 3
        str = "ab";
        pattern = ".*";
        Console.WriteLine($"Example 3: {SolveRegularExpressionMatching(str, pattern)}");
    }

    //Creating private variables instead of sending them in the recursive function to save memory
    private bool?[,] cachedPositions;
    private string str;
    private string pattern;
    private bool SolveRegularExpressionMatching(string str, string pattern)
    {
        this.cachedPositions = new bool?[str.Length + 1, pattern.Length + 1];
        this.str = str;
        this.pattern = pattern;

        return RecursiveSolution(0, 0);
    }

    private bool RecursiveSolution(int i, int j)
    {
        //Both pattern and string have been fully evaluated without failing -> pattern contains whole string
        if (i >= str.Length && j >= pattern.Length)
            return true;

        //Pattern has been fully evaluated but iterator of the string didn't reach the end -> pattern does not contain the whole string
        if (j >= pattern.Length)
            return false;

        if (cachedPositions[i, j].HasValue)
            return cachedPositions[i, j].Value;

        bool matchPattern = i < str.Length && (pattern[j] == '.' || pattern[j] == str[i]);

        //Validate index before accessing and check if next char is an asterisk
        if (j + 1 < pattern.Length && pattern[j + 1] == '*')
        {
            //str[i] is either equal to the char after the asterisk, or equal to the char before the asterisk in the pattern
            //We check after the asterisk as well because '*' matches zero or more of the preceding character
            //Order of the checks can increase speed but depends on the input..
            cachedPositions[i, j] = RecursiveSolution(i, j + 2) || (matchPattern && RecursiveSolution(i + 1, j));
            return cachedPositions[i, j].Value;
        }

        //Normal pattern matching after '*' was evaluated
        if (matchPattern)
        {
            cachedPositions[i, j] = RecursiveSolution(i + 1, j + 1);
            return cachedPositions[i, j].Value;
        }

        //If both checks above fail, there's no match
        cachedPositions[i, j] = false;
        return false;
    }
}