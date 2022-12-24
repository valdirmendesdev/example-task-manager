namespace OrbitTaskManager.Core;

public class TaskManager
{

  private List<ITask> tasks;

  public TaskManager()
  {
    this.tasks = getInstancesOfExecutableTasks();
  }

  private List<ITask> getInstancesOfExecutableTasks()
  {
    IEnumerable<Type> _types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(t => t.GetInterfaces().Contains(typeof(ITask)));
    var tasks = new List<ITask>();
    //Genérico => Código que evolui ou código auto evolutivo!
    foreach (var _type in _types)
    {
      if (_type.IsAbstract)
      {
        continue;
      }

      //_type.Namespace.contains (*test*) => ideal
      if (_type.IsNotPublic) //BAD - Code Smell
      {
        continue;
      }

      //Buscar o status da tarefa no banco de dados neste momento!
      //Dependência de interface de repositório!
      ITask task = (ITask)Activator.CreateInstance(_type, "Não executada");
      tasks.Add(task);
    }
    return tasks;
  }

  //quais são as tarefas [ok]
  //O estado das tarefas [ok]
  //Gerencia a execução de tarefas [ok]
  public List<ITask> getExecutableTasks()
  {
    return this.tasks;
  }

  //Objeto de retorno com status, msg...
  public string executeTask(ITask task)
  {
    if (task.alreadyExecuted())
    {
      return "Tarefa já executada!";
    }

    // Gestão de evento da tarefa!
    var result = task.execute();

    if (result)
    {
      task.setExecutionStatus("Executado com sucesso");
    }
    else
    {
      task.setExecutionStatus("Executado com erro");
    }

    return $"Tarefa: {task.getExecutionStatus()}";
  }
}