using System.Diagnostics;

namespace LeetCode;

public abstract class BaseProblem : ITestable
{
    protected Stopwatch _stopwatch;
    protected Stats _stats;
    public int GetProblemNum() => _stats.ProblemNumber;
    public Stats GetProblemStats() => _stats;

    public void SetProblemStats(int problemNum, string problemName, Difficulty difficulty) =>
        _stats = new Stats(problemNum, problemName, difficulty, -1, -1);

    public void ExecuteTest()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        
        //Terrible way to profile it. Not even using big samples and getting the average..
        long prevMemoryUsage = Process.GetCurrentProcess().VirtualMemorySize64;
        _stopwatch = Stopwatch.StartNew();
        ActualExecuteTest();
        _stopwatch.Stop();
        long currMemoryUsage = Process.GetCurrentProcess().VirtualMemorySize64;
        
        _stats.Runtime = _stopwatch.ElapsedMilliseconds;
        _stats.Memory = Math.Round((currMemoryUsage - prevMemoryUsage) / 1024f / 1024f, 2, MidpointRounding.ToEven);
        
        PrintInfo();
    }

    protected virtual void ActualExecuteTest()
    {
        
    }

    private void PrintInfo() => Console.WriteLine(_stats.ToString());
}