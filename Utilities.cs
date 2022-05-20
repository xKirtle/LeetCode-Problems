public interface ITestable
{
    int GetProblemNum();
    void Test();

    Stats GetProblemStats();
}

public struct Stats
{
    public string ProblemName;
    public Difficulty Difficulty;
    public double Runtime;
    public double Memory;

    public Stats(string problemName, Difficulty difficulty, double runtime, double memory)
    {
        ProblemName = problemName;
        Difficulty = difficulty;
        Runtime = runtime;
        Memory = memory;
    }

    public override string ToString() => $"Problem: {ProblemName}\nDifficulty: {(Difficulty.ToString())} | Runtime: {Runtime} ms | Memory: {Memory} MB\n";
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}