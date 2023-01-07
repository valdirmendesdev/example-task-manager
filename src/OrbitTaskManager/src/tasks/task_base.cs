namespace OrbitTaskManager.Tasks;

// Uma classe abstrata (abstract) não pode ser instanciada!!!
// Também serve de modelo (estrutura), mas pode possuir código e propriedades!!
public abstract class TaskBase : ITask
{
  public Version CurrentVersion { get; private set; }

  public string Title { get; private set; }

  public string LongDescription { get; set; }

  public virtual bool IsCompatible => true;

  public bool IsRepeatable { get; private set; }

  public string ParentModule { get; private set; }

  public abstract void Do();

  public abstract void Undo();

  private void fillProperties(Version currentVersion,
                  string title,
                  string parentModule,
                  bool isRepeatable = false,
                  string longDescription = "")
  {
    this.CurrentVersion = currentVersion;
    this.Title = title;
    this.LongDescription = longDescription;
    this.IsRepeatable = isRepeatable;
    this.ParentModule = parentModule;
  }

  public TaskBase(Version currentVersion,
                  string title,
                  string parentModule,
                  bool isRepeatable = false,
                  string longDescription = "")
  {
    this.fillProperties(currentVersion, title, parentModule, isRepeatable, longDescription);
  }

  public TaskBase(string currentVersion,
                string title,
                string parentModule,
                bool isRepeatable = false,
                string longDescription = "")
  {
    Version _currentVersion = new Version(currentVersion);
    this.fillProperties(_currentVersion, title, parentModule, isRepeatable, longDescription);
  }
}