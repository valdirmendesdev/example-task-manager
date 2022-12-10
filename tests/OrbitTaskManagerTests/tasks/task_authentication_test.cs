public class TaskAuthenticationTest
{
  private TaskAuthentication cut;

  public TaskAuthenticationTest() => cut = new TaskAuthentication("1.0.0", "Task title", false, false, "OrbitTaskManager.Core");

  [Fact]
  public void ShouldExecuteMethod()
  {
    Assert.False(cut.execute());
  }

}