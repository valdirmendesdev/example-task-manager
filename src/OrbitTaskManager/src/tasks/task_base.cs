namespace OrbitTaskManager.Tasks;


// Uma classe abstrata (abstract) não pode ser instanciada!!!
// Também serve de modelo (estrutura), mas pode possuir código e propriedades!!
public abstract class TaskBase : ITask
{
  private string _version;
  private string _title;
  private string _longDescription;
  private bool _repeatable;
  private bool _compatible; //check!
  private string _parent;
  private string _executionStatus; //check!

  public abstract bool execute();

  public TaskBase(string version, string title, bool compatible, bool repeatable, string parent, string executionStatus = "Não executada")
  {
    this._version = version;
    this._title = title;
    this._compatible = compatible;
    this._repeatable = repeatable;
    this._parent = parent;
    this._executionStatus = executionStatus;
    this._longDescription = "";
  }

  public bool alreadyExecuted()
  {
    return this.getExecutionStatus() == "Não executada" ? false : true;
  }

  public bool IsCompatible()
  {
    return this._compatible;
  }

  public string getExecutionStatus()
  {
    return this._executionStatus;
  }

  public string LongDescription()
  {
    return this._longDescription;
  }

  public string ParentModule()
  {
    return this._parent;
  }

  public bool IsRepeatable()
  {
    return this._repeatable;
  }


  public string Title()
  {
    return this._title;
  }

  public string Version()
  {
    return this._version;
  }

  public void setExecutionStatus(string executionStatus)
  {
    this._executionStatus = executionStatus;
  }

  public void SetLongDescription(string longDescription)
  {
    this._longDescription = longDescription;
  }
}