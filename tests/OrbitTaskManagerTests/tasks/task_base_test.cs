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
    throw new NotImplementedException();
  }
}

public class TaskBaseTest
{
  private TaskBase cut;

  public TaskBaseTest() => cut = new local_task_for_testing("1.0.0", "Task title", false, false, "OrbitTaskManager.Core");

  [Fact]
  public void ShouldGetTheVersionOfTheTask()
  {
    Assert.Equal("1.0.0", cut.getVersion());
  }

  [Fact]
  public void ShouldReturnTheTitleOfTheTask()
  {
    Assert.Equal("Task title", cut.getTitle());
  }

  [Fact]
  public void ShouldReturnTheTaskParentModule()
  {
    Assert.Equal("OrbitTaskManager.Core", cut.getParentModule());
  }

  [Fact]
  public void ShouldReturnIfTaskIsRepeatable()
  {
    Assert.False(cut.getRepeatable());
    cut = new local_task_for_testing("1.0.0", "Task title", false, true, "OrbitTaskManager.Core");
    Assert.True(cut.getRepeatable());
  }

  [Fact]
  public void ShouldReturnIfTaskIsCompatibleWithEnvironment()
  {
    Assert.False(cut.getCompatibility());
    cut = new local_task_for_testing("1.0.0", "Task title", true, true, "OrbitTaskManager.Core");
    Assert.True(cut.getCompatibility());
  }

  [Fact]
  public void ShouldChangeLongDescription()
  {
    cut.setLongDescription("Long description");
    Assert.Equal("Long description", cut.getLongDescription());
  }

  [Fact]
  public void ShouldChangeTheExecutionStatus()
  {
    Assert.Equal("Não executada", cut.getExecutionStatus());
    cut.setExecutionStatus("Não executada");
    Assert.Equal("Não executada", cut.getExecutionStatus());
  }
}