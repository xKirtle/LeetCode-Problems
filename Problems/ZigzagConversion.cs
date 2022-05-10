public partial class Problems
{
    public static void ZigzagConversionTest()
    {
        //Example 1
        string s = "PAYPALISHIRING";
        int numRows = 3;
        Console.WriteLine($"Example 1: {ZigzagConversion(s, numRows)}");
        
        //Example 2
        s = "PAYPALISHIRING";
        numRows = 4;
        Console.WriteLine($"Example 2: {ZigzagConversion(s, numRows)}");
        
        //Example 3
        s = "A";
        numRows = 1;
        Console.WriteLine($"Example 3: {ZigzagConversion(s, numRows)}");
        
        //column * 2*(numRows-1) + row -> vertical pattern
        //column * 2*(numRows-1) - row -> diagonal pattern
        /* numRows = 4
            0       6         12      18
            |     / |       / |     / |
            1    5  7     11  13  17  19
            |   /   |    /    |  /    |
            2  4    8  10    14 16    20
            | /     | /      | /      |
            3       9       15        21
        */
        
        /* numRows = 2 (edge case)
            0  2  4  6
            | /| /| /|
            1  3  5  7
        */
    }

    private static string ZigzagConversion(string s, int numRows)
    {
        if (s.Length == 1 || numRows == 1 || s.Length <= numRows)
            return s;
        
        string result = "";
        int incrementalValue = 2 * (numRows - 1);
        int numColumns = (int) Math.Ceiling(s.Length / (double) incrementalValue);
        
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numColumns; column++)
            {
                //Vertical pattern
                int index = column * incrementalValue + row;
                if (index < s.Length)
                    result += s[index];

                if (row != 0 && row != numRows - 1)
                {
                    //Diagonal pattern
                    index = (column + 1) * incrementalValue - row;
                    if (index < s.Length)
                        result += s[index];
                }
            }
            
        }

        return result;
    }
}