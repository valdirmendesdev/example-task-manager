public class TaskAuthenticationTest
{
  private TaskAuthentication cut;

  public TaskAuthenticationTest() => cut = new TaskAuthentication();

  [Fact]
  public void ShouldExecuteMethod()
  {
    Assert.False(cut.execute());
  }

}