List<ITestable> instances = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
    .Where(t => !t.IsInterface && !t.IsAbstract && typeof(ITestable).IsAssignableFrom(t))
    .Select(t => (ITestable) Activator.CreateInstance(t)).ToList();
instances.Sort((x, y) => x.GetProblemNum() - y.GetProblemNum());

int problemNum = 1;
instances[problemNum-1].ExecuteTest();