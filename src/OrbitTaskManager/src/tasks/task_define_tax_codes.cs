using OrbitTaskManager.Core;

public class TaskDefineTaxCodes : TaskBase
{
  public TaskDefineTaxCodes(string executionStatus = "Não executada") : base("2.0.0", "Popula tabela com códigos de imposts", true, false, "OrbitTaskManager.Core", executionStatus)
  {
  }

  public override bool execute()
  {
    Console.WriteLine($"Executando: {this.getTitle()}!");
    this.setExecutionStatus("Executado com sucesso");
    return true;
  }
}