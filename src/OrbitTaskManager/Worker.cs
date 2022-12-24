using OrbitTaskManager.Core;

namespace OrbitTaskManager;
public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;

  public Worker(ILogger<Worker> logger)
  {
    _logger = logger;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    var taskManager = new TaskManager();

    while (!stoppingToken.IsCancellationRequested)
    {
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

      //Genérico => Código que evolui ou código auto evolutivo!
      foreach (var task in taskManager.getExecutableTasks())
      {
        Console.WriteLine(taskManager.executeTask(task));
      }

      await Task.Delay(1000, stoppingToken);
    }
  }
}
