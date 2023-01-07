// classe : classe => Representa herança
// Classe : interface => representa implementação da interface
// classe : classe, interface, classe .... 
public class local_task_for_testing : TaskBase
{
  public local_task_for_testing(string currentVersion, string title, string parentModule, bool isRepeatable = false, string longDescription = "") : base(currentVersion, title, parentModule, isRepeatable, longDescription)
  {
  }

  public override void Do()
  {
    throw new NotImplementedException();
  }

  public override void Undo()
  {
    throw new NotImplementedException();
  }
}

public class TaskBaseTest
{
  private TaskBase? cut;

  private local_task_for_testing createInstanceForTesting(
    string strVersion = "1.0.0",
    string title = "Task title",
    bool isRepeatable = false,
    string parentModule = "OrbitTaskManager.Core",
    string longDescription = "")
  {
    return new local_task_for_testing(strVersion, title, parentModule, isRepeatable, longDescription);
  }

  [Fact]
  public void ShouldCreateAValidInstance()
  {
    cut = createInstanceForTesting();
    Assert.Equal("1.0.0", cut.CurrentVersion.ToString());
    Assert.Equal("Task title", cut.Title);
    Assert.Empty(cut.LongDescription);
    Assert.True(cut.IsCompatible);
    Assert.False(cut.IsRepeatable);
    Assert.Equal("OrbitTaskManager.Core", cut.ParentModule);

    cut = createInstanceForTesting(isRepeatable: true, longDescription: "Long description");
    Assert.True(cut.IsRepeatable);
    Assert.Equal("Long description", cut.LongDescription);
  }

  [Theory]
  [InlineData("")]
  [InlineData("1")]
  [InlineData("1.a")]
  [InlineData("foo.bar")]
  [InlineData(".0.")]
  public void ShouldNotCreateAValidInstanceWithInvalidVersionParameter(string invalidVersion)
  {
    Assert.Throws<ArgumentException>(() =>
    {
      cut = createInstanceForTesting(strVersion: invalidVersion);
    });
  }
}