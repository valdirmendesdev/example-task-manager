namespace OrbitTaskManager;
using OrbitTaskManager.Core;

public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;

  public Worker(ILogger<Worker> logger)
  {
    _logger = logger;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

      var task1 = new TaskAuthentication("2.0.0", "Autenticação", true, true, "OrbitTaskManager.Core");
      var task2 = new TaskEnvironment();

      task1.execute();
      task2.execute();

      await Task.Delay(1000, stoppingToken);
    }
  }
}
