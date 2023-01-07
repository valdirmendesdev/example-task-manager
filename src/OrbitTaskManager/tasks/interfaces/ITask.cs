namespace OrbitTaskManager.Tasks;

public interface ITask
{
  Version LatestVersion { get; }

  Version? CurrentExecutedVersion { get; }

  string Title { get; }

  string LongDescription { get; set; }

  bool AnyExecutedVersion { get; }

  bool IsCompatible { get; }

  bool IsRepeatable { get; }

  string ParentModule { get; }

  void Do();

  void Undo();
}