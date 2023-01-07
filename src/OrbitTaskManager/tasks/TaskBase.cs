namespace OrbitTaskManager.Tasks;

// Uma classe abstrata (abstract) não pode ser instanciada!!!
// Também serve de modelo (estrutura), mas pode possuir código e propriedades!!
public abstract class TaskBase : ITask
{
  public Version LatestVersion { get; private set; }

  public string Title { get; private set; } = string.Empty;

  public string LongDescription { get; set; } = string.Empty;

  public virtual bool IsCompatible => true;

  public bool IsRepeatable { get; private set; } = false;

  public string ParentModule { get; private set; } = string.Empty;

  public Version? CurrentExecutedVersion => throw new NotImplementedException();

  public bool AnyExecutedVersion => CurrentExecutedVersion != null;

  public abstract void Do();

  public abstract void Undo();

  public TaskBase(string latestVersion,
                  string title,
                  string parentModule,
                  bool isRepeatable = false,
                  string longDescription = "")
  {
    Version? convertedVersion;
    if (!Version.TryParse(latestVersion, out convertedVersion))
    {
      throw new ArgumentException("Version format is not valid", "latestVersion");
    }
    this.LatestVersion = convertedVersion;
    this.Title = title;
    this.LongDescription = longDescription;
    this.IsRepeatable = isRepeatable;
    this.ParentModule = parentModule;
  }
}