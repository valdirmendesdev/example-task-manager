public class TaskEnvironmentTest
{
  private TaskEnvironment cut;

  public TaskEnvironmentTest() => cut = new TaskEnvironment();

  [Fact]
  public void ShouldHaveTheInitialValues()
  {
    Assert.Equal("1.0.0", cut.getVersion());
    Assert.Equal("Define o ambiente de execução", cut.getTitle());
    Assert.True(cut.getCompatibility());
    Assert.False(cut.getRepeatable());
    Assert.Equal("OrbitTaskManager.Core", cut.getParentModule());
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