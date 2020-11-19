using Application.Shared.Models;
using System;
using System.Linq;
using LibGit2Sharp;
using System.IO;

namespace ArticleData.Generator
{
  public class GitClient : IDisposable
  {
    private readonly Repository repository;
    private readonly CommitFilter commitFilter;

    public GitClient(string pathToRepository)
    {
      var repoPath = Repository.Discover(pathToRepository);
      this.repository = new Repository(repoPath);
      this.commitFilter = new CommitFilter
      {
        SortBy = CommitSortStrategies.Topological
      };
    }

    public void GetFileInfo(ArticleFileInfo articleFileInfo)
    {
      var pathToFile = Path.Combine(articleFileInfo.Path, articleFileInfo.FileName)
        + articleFileInfo.FileExtension;
      var latestCommit = this.repository.Commits
        .QueryBy(this.commitFilter)
        .Where(c => c.Tree[pathToFile] != null)
        .First();
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
