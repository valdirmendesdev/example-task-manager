namespace OrbitTaskManager.Tasks;

public class TaskExecutionInfo
{
  public Version ExecutedVersion { get; private set; }

  public String ExecutedBy { get; private set; }

  public DateTime ExecutedAt { get; private set; }

  public TaskExecutionInfo(Version executedVersion, string executedBy, DateTime executedAt)
  {
    ExecutedVersion = executedVersion;
    ExecutedBy = executedBy;
    ExecutedAt = executedAt;
  }
}

public interface ITaskRepository
{
  TaskExecutionInfo? GetExecutionInfo(ITask task);
  void SaveExecutionInfo(ITask task);
}