using Application.Shared.Models;
using LibGit2Sharp;

namespace PageData.Generator;

public class GitClient : IDisposable
{
  public string RootPathToRepository { get; private set; }

  private readonly Repository repository;
  private readonly CommitFilter commitFilter;

  public GitClient(string path)
  {
    RootPathToRepository = Repository
      .Discover(path)
      .Replace(".git/", string.Empty);
    this.repository = new Repository(RootPathToRepository);
    this.commitFilter = new CommitFilter
    {
      FirstParentOnly = true
    };
  }

  public void GetFileInfo(PageFileInfo pageFileInfo, string rootFolder)
  {
    var pathToFile = Path.Combine(rootFolder, pageFileInfo.Path, pageFileInfo.FileName)
      + pageFileInfo.FileExtension;
    var latestCommit = this.repository.Commits
      .QueryBy(pathToFile, this.commitFilter)
      .First().Commit;
    pageFileInfo.LatestUpdate = latestCommit.Committer.When;
    pageFileInfo.LatestAuthor = latestCommit.Committer.Name;
  }

  public void Dispose()
  {
    GC.SuppressFinalize(this);
    this.repository.Dispose();
  }
}
