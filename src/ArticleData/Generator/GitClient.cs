using Application.Shared.Models;
using System;
using System.Linq;
using LibGit2Sharp;

namespace ArticleData.Generator
{
  public class GitClient : IDisposable
  {
    private readonly Repository repository;

    public GitClient(string pathToRepository)
    {
      var repoPath = Repository.Discover(pathToRepository);
      this.repository = new Repository(repoPath);
    }

    public void GetFileInfo(ArticleFileInfo articleFileInfo)
    {
      var commit = this.repository.Commits.QueryBy(articleFileInfo.Path).Take(1).Last().Commit;
      articleFileInfo.LatestUpdate = commit.Author.When;
      articleFileInfo.LatestAuthor = commit.Author.Name;
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
      this.repository.Dispose();
    }
  }
}
