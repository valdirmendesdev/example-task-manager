namespace OrbitTaskManager.Tasks;

public interface ITask
{

  // Change version - PROBLEMA - IMPORTANT! (Vai virar classe ou tipo forte!)
  // "Obsessividade" por tipos primitivos!
  // format: 1.0.0

  Version CurrentVersion { get; }

  string Title { get; }

  string LongDescription { get; set; }

  bool IsCompatible { get; }

  bool IsRepeatable { get; }

  string ParentModule { get; }

  void Do();

  void Undo();
}