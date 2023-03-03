namespace OrbitTaskManager.Tasks;

// Uma classe abstrata (abstract) não pode ser instanciada!!!
// Também serve de modelo (estrutura), mas pode possuir código e propriedades!!
public abstract class TaskBase : ITask
{
  public Version CurrentVersion { get; private set; }

  public string Title { get; private set; } = string.Empty;

  public string LongDescription { get; set; } = string.Empty;

  public virtual bool IsCompatible => true;

  public bool IsRepeatable { get; private set; } = false;

  public string ParentModule { get; private set; } = string.Empty;

  public abstract void Do();

  public abstract void Undo();

  public TaskBase(string currentVersion,
                  string title,
                  string parentModule,
                  bool isRepeatable = false,
                  string longDescription = "")
  {
    Version? convertedVersion;
    if (!Version.TryParse(currentVersion, out convertedVersion))
    {
      throw new ArgumentException("Version format is not valid", "currentVersion");
    }
    this.CurrentVersion = convertedVersion;
    this.Title = title;
    this.LongDescription = longDescription;
    this.IsRepeatable = isRepeatable;
    this.ParentModule = parentModule;
  }
}