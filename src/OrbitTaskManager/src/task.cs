public interface ITask
{

  // Change version - PROBLEMA - IMPORTANT! (Vai virar classe ou tipo forte!)
  // "Obsessividade" por tipos primitivos!
  // format: 1.0.0

  string getVersion(); //get version

  string getTitle();

  void setLongDescription(string longDescription);

  string getLongDescription();

  //Vai virar Enum - 
  //Execution Status => vai virar objeto com dados de data e usuário.
  // Quando foi executado!
  void setExecutionStatus(string executionStatus);

  string getExecutionStatus();

  bool getCompatibility();

  bool getRepeatable();

  string getParentModule();

  bool execute();
}