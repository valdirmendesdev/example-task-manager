// classe : classe => Representa herança
// Classe : interface => representa implementação da interface
// classe : classe, interface, classe .... 
using OrbitTaskManagerTests.Utils;

public class TaskBaseTest
{
  private TaskBase? cut;

  [Fact]
  public void ShouldCreateAValidInstance()
  {
    cut = Local_task_for_testing.CreateInstanceForTesting();
    Assert.Equal("1.0.0", cut.CurrentVersion.ToString());
    Assert.Equal("Task title", cut.Title);
    Assert.Empty(cut.LongDescription);
    Assert.True(cut.IsCompatible);
    Assert.False(cut.IsRepeatable);
    Assert.Equal("OrbitTaskManager.Core", cut.ParentModule);

    cut = Local_task_for_testing.CreateInstanceForTesting(isRepeatable: true, longDescription: "Long description");
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
      cut = Local_task_for_testing.CreateInstanceForTesting(strVersion: invalidVersion);
    });
  }
}