using OrbitTaskManager.Core;

public class TaskAuthentication : TaskBase
{
  public TaskAuthentication(string version, string title, bool compatible, bool repeatable, string parent, string executionStatus = "Não executada") : base(version, title, compatible, repeatable, parent, executionStatus)
  {
  }

  public override bool execute()
  {
    Console.WriteLine("Executando a tarefa de autenticação");
    return false;
  }
}