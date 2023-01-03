public class TaskEnvironmentTest
{
  private TaskEnvironment cut;

  public TaskEnvironmentTest() => cut = new TaskEnvironment();

  [Fact]
  public void ShouldHaveTheInitialValues()
  {
    Assert.Equal("1.0.0", cut.Version());
    Assert.Equal("Define o ambiente de execução", cut.Title());
    Assert.True(cut.IsCompatible());
    Assert.False(cut.IsRepeatable());
    Assert.Equal("OrbitTaskManager.Core", cut.ParentModule());
    Assert.Equal("Não executada", cut.getExecutionStatus());
  }

  [Fact]
  public void ShouldCreateTaskInstanceWithCustomExecutionStatus()
  {
    cut = new TaskEnvironment("Executada com sucesso");
    Assert.Equal("Executada com sucesso", cut.getExecutionStatus());
  }

  [Fact]
  public void ShouldPossibleExecuteTheTask()
  {
    Assert.True(cut.execute());
  }
}