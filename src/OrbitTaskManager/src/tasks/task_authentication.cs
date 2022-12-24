using OrbitTaskManager.Core;

public class TaskAuthentication : TaskBase
{
  public TaskAuthentication(string executionStatus = "Não executada") : base("2.0.0", "Autenticação", true, true, "OrbitTaskManager.Core", executionStatus)
  {
  }

  public override bool execute()
  {
    Console.WriteLine("Executando a tarefa de autenticação");
    this.setExecutionStatus("Executado com sucesso");
    return true;
  }
}