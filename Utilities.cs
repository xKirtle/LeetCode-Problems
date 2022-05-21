public interface ITestable
{
    abstract int GetProblemNum();
    abstract Stats GetProblemStats();
    abstract void ExecuteTest();
}

public struct Stats
{
    public int ProblemNumber;
    public string ProblemName;
    public Difficulty Difficulty;
    public double Runtime;
    public double Memory;

    public Stats(int problemNumber, string problemName, Difficulty difficulty, double runtime, double memory)
    {
        ProblemNumber = problemNumber;
        ProblemName = problemName;
        Difficulty = difficulty;
        Runtime = runtime;
        Memory = memory;
    }

    public override string ToString() => $"Problem: {ProblemNumber}. {ProblemName}\nDifficulty: {(Difficulty.ToString())} | Runtime: {Runtime} ms | Memory: {Memory} MB\n";
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}