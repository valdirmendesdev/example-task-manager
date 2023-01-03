public class TaskManagerTest
{
  private TaskManager cut;
  public TaskManagerTest() => cut = new TaskManager();

  [Fact]
  public void ShouldReturnTasksList()
  {
    var tasksList = cut.getExecutableTasks(); // Livro - Clean Code
    // Assert.Equal(tasksList.Count, 4); // BAD! Não é genérico
    Assert.NotEqual(tasksList.Count, 0); // Não é o ideal, mas é melhor!
  }

  [Fact]
  public void ShouldManageTaskExecutionState()
  {
    var tasksList = cut.getExecutableTasks();
    var task = tasksList[0];
    task.execute(); // perigoso!

    Assert.Equal(task.getExecutionStatus(), "Executado com sucesso");

    tasksList = cut.getExecutableTasks();
    task = tasksList[0];
    Assert.Equal(task.getExecutionStatus(), "Executado com sucesso");
  }

  [Fact]
  public void ShouldExecuteATask()
  {
    var tasksList = cut.getExecutableTasks();
    var task = tasksList[0];
    // var selectedTasks = new List<ITask>();
    // selectedTasks.Add(task);
    var result = cut.executeTask(task);
    Assert.Equal(result, "Tarefa: Executado com sucesso");

    result = cut.executeTask(task);
    Assert.Equal(result, "Tarefa já executada!");
  }

  [Fact]
  public void ShouldBePossibleCheckATaskExecutionStatus()
  {

  }
}
