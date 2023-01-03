// classe : classe => Representa herança
// Classe : interface => representa implementação da interface
// classe : classe, interface, classe .... 
class local_task_for_testing : TaskBase
{
  public local_task_for_testing(string version, string title, bool compatible, bool repeatable, string parent, string executionStatus = "Não executada") : base(version, title, compatible, repeatable, parent, executionStatus)
  {
  }

  public override bool execute()
  {
    if (this.alreadyExecuted())
    {
      return false;
    }

    this.setExecutionStatus("Executado com sucesso");
    return true;
  }
}

public class TaskBaseTest
{
  private TaskBase cut;

  public TaskBaseTest() => cut = new local_task_for_testing("1.0.0", "Task title", false, false, "OrbitTaskManager.Core");

  [Fact]
  public void ShouldGetTheVersionOfTheTask()
  {
    Assert.Equal("1.0.0", cut.Version());
  }

  [Fact]
  public void ShouldReturnTheTitleOfTheTask()
  {
    Assert.Equal("Task title", cut.Title());
  }

  [Fact]
  public void ShouldReturnTheTaskParentModule()
  {
    Assert.Equal("OrbitTaskManager.Core", cut.ParentModule());
  }

  [Fact]
  public void ShouldReturnIfTaskIsRepeatable()
  {
    Assert.False(cut.IsRepeatable());
    cut = new local_task_for_testing("1.0.0", "Task title", false, true, "OrbitTaskManager.Core");
    Assert.True(cut.IsRepeatable());
  }

  [Fact]
  public void ShouldReturnIfTaskIsCompatibleWithEnvironment()
  {
    Assert.False(cut.IsCompatible());
    cut = new local_task_for_testing("1.0.0", "Task title", true, true, "OrbitTaskManager.Core");
    Assert.True(cut.IsCompatible());
  }

  [Fact]
  public void ShouldChangeLongDescription()
  {
    cut.SetLongDescription("Long description");
    Assert.Equal("Long description", cut.LongDescription());
  }

  [Fact]
  public void ShouldChangeTheExecutionStatus()
  {
    Assert.Equal("Não executada", cut.getExecutionStatus());
    cut.setExecutionStatus("Não executada");
    Assert.Equal("Não executada", cut.getExecutionStatus());
  }

  [Fact]
  public void ShouldNotExecuteTaskTwice()
  {
    Assert.Equal(cut.getExecutionStatus(), "Não executada");
    Assert.True(cut.execute());
    Assert.Equal(cut.getExecutionStatus(), "Executado com sucesso");
    Assert.False(cut.execute());
  }
}