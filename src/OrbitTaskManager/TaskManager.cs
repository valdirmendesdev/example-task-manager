namespace OrbitTaskManager.Tasks;

public class TaskManager
{
  private ITaskRepository _taskRepo;

  public TaskManager(ITaskRepository taskRepo)
  {
    this._taskRepo = taskRepo;
  }

  //verificar status atual da tarefa
  //Executar a tarefa ✅
  //Salvar no banco status de execução da tarefa ✅

  public void DoTask(ITask task)
  {
    _ = task ?? throw new ArgumentNullException(nameof(task));

    TaskExecutionInfo? executionInfo = _taskRepo.GetExecutionInfo(task);

    if (executionInfo is not null) throw new ApplicationException("You cannot execute a task that has already been executed");

    task.Do();
    _taskRepo.SaveExecutionInfo(task);
  }

  // private List<ITask> getInstancesOfExecutableTasks()
  // {
  //   IEnumerable<Type> _types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(t => t.GetInterfaces().Contains(typeof(ITask)));
  //   var tasks = new List<ITask>();
  //   //Genérico => Código que evolui ou código auto evolutivo!
  //   foreach (var _type in _types)
  //   {
  //     if (_type.IsAbstract)
  //     {
  //       continue;
  //     }

  //     //_type.Namespace.contains (*test*) => ideal
  //     if (_type.IsNotPublic) //BAD - Code Smell
  //     {
  //       continue;
  //     }

  //     //Buscar o status da tarefa no banco de dados neste momento!
  //     //Dependência de interface de repositório!
  //     ITask? task = Activator.CreateInstance(_type) as ITask;
  //     if (task != null)
  //     {
  //       tasks.Add(task);
  //     }
  //   }
  //   return tasks;
  // }
}

//Build a class to represent a task manager
