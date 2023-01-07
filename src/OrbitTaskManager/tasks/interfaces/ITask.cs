namespace OrbitTaskManager.Tasks;

public interface ITask
{
  Version CurrentVersion { get; }

  string Title { get; }

  string LongDescription { get; set; }

  bool IsCompatible { get; }

  bool IsRepeatable { get; }

  string ParentModule { get; }

  void Do();

  void Undo();
}