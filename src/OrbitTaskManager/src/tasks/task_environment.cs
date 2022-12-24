namespace OrbitTaskManager.Core;

public class TaskEnvironment : TaskBase
{
  public TaskEnvironment(string executionStatus = "Não executada") : base("1.0.0", "Define o ambiente de execução", true, false, "OrbitTaskManager.Core", executionStatus)
  {
  }

  public override bool execute()
  {
    Console.WriteLine("Executando a tarefa de mudança de ambiente");
    this.setExecutionStatus("Executado com sucesso");
    return true;
  }
}