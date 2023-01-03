namespace OrbitTaskManager.Tasks;

public interface ITask
{

  // Change version - PROBLEMA - IMPORTANT! (Vai virar classe ou tipo forte!)
  // "Obsessividade" por tipos primitivos!
  // format: 1.0.0

  string Version(); //get version

  string Title();

  void SetLongDescription(string longDescription);

  string LongDescription();

  //Vai virar Enum - 
  //Execution Status => vai virar objeto com dados de data e usuário.
  // Quando foi executado!
  void setExecutionStatus(string executionStatus);

  string getExecutionStatus();

  bool IsCompatible();

  bool IsRepeatable();

  string ParentModule();

  bool execute();

  bool alreadyExecuted();
}