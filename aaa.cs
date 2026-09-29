Zms z=new();
await z.ProcessBatchAsync();
int logicalCount = Environment.ProcessorCount;
Console.WriteLine($"逻辑处理器数: {logicalCount}");
class Zms
{
  public async Task ProcessBatchAsync()
{
    var tasks = new List<Task>();
    
    for (int i = 0; i < 100; i++)
    {
        int taskId = i; // 注意闭包捕获问题
        tasks.Add(Task.Run(() =>
        {
            Console.WriteLine($"处理任务 {taskId}, 线程 {Environment.CurrentManagedThreadId}");
            Thread.Sleep(100);
        }));
    }
    
    await Task.WhenAll(tasks);
    Console.WriteLine("全部完成");
}
}