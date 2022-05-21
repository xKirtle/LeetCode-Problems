List<ITestable> instances = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
    .Where(t => !t.IsInterface && typeof(ITestable).IsAssignableFrom(t))
    .Select(t => (ITestable) Activator.CreateInstance(t)).ToList();
instances.Sort((x, y) => x.GetProblemNum() - y.GetProblemNum());

int problemNum = 1;
Console.WriteLine(instances[problemNum - 1].GetProblemStats().ToString());
instances[problemNum-1].Test();