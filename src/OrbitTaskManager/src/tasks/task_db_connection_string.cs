namespace OrbitTaskManager.Tasks;

public class TaskDbConnectionString : TaskBase
{
  public TaskDbConnectionString(string executionStatus = "Não executada") : base("1.0.0", "Define a string de conexão com o banco de dados", true, false, "OrbitTaskManager.Core", executionStatus)
  {
  }

  public override bool execute()
  {
    Console.WriteLine($"Executando: {this.Title()}!");
    this.setExecutionStatus("Executado com sucesso");
    return true;
  }
}