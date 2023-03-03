using OrbitTaskManagerTests.Utils;

public class TaskManagerTest
{
  private TaskManager cut;
  private Mock<ITaskRepository> taskRepo;

  public TaskManagerTest()
  {
    taskRepo = new Mock<ITaskRepository>();
    cut = new TaskManager(taskRepo.Object);
  }

  [Fact]
  public void ShouldExecuteATaskSuccessfully()
  {
    Local_task_for_testing taskForTest = Local_task_for_testing.CreateInstanceForTesting();

    taskRepo.Setup(t => t.SaveExecutionInfo(taskForTest));

    cut.DoTask(taskForTest);
    Assert.True(taskForTest.DoWasCalled);
    taskRepo.Verify(t => t.SaveExecutionInfo(taskForTest), Times.Once);
  }

  [Fact]
  public void ShouldThrowExceptionIfTheTaskObjectIsNull()
  {
    Action checkException = () =>
    {
      cut.DoTask(task: Local_task_for_testing.GetANullInstance());
    };
    Assert.Throws<ArgumentNullException>(checkException);
  }
}
