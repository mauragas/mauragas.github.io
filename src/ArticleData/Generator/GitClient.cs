using Application.Shared.Models;
using System;
using System.Linq;
using LibGit2Sharp;
using System.IO;

namespace ArticleData.Generator
{
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

    public void GetFileInfo(ArticleFileInfo articleFileInfo, string rootFolder)
    {
      var pathToFile = Path.Combine(rootFolder, articleFileInfo.Path, articleFileInfo.FileName)
        + articleFileInfo.FileExtension;
      var latestCommit = this.repository.Commits
        .QueryBy(pathToFile, this.commitFilter)
        .First().Commit;
      articleFileInfo.LatestUpdate = latestCommit.Committer.When;
      articleFileInfo.LatestAuthor = latestCommit.Committer.Name;
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
      this.repository.Dispose();
    }
  }
}
