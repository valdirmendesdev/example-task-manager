namespace OrbitTaskManagerTests.Utils;

public class Local_task_for_testing : TaskBase
{
  public bool DoWasCalled { get; private set; }
  public bool UndoWasCalled { get; private set; }

  public Local_task_for_testing(string currentVersion, string title, string parentModule, bool isRepeatable = false, string longDescription = "") : base(currentVersion, title, parentModule, isRepeatable, longDescription)
  {
    this.DoWasCalled = false;
    this.UndoWasCalled = false;
  }

  public override void Do()
  {
    this.DoWasCalled = true;
  }

  public override void Undo()
  {
    this.UndoWasCalled = true;
  }

  public static Local_task_for_testing CreateInstanceForTesting(
    string strVersion = "1.0.0",
    string title = "Task title",
    bool isRepeatable = false,
    string parentModule = "OrbitTaskManager.Core",
    string longDescription = "")
  {
    return new Local_task_for_testing(strVersion, title, parentModule, isRepeatable, longDescription);
  }

  public static ITask? GetANullInstance()
  {
    return null;
  }
}