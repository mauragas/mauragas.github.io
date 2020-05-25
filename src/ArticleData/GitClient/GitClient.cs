using Application.Shared.Models;
using System;
using System.Linq;
using LibGit2Sharp;

namespace ArticleData.GitClient
{
  public class GitClient : IDisposable
  {
    private readonly Repository _repository;

    public GitClient(string pathToRepository)
    {
      string repoPath = Repository.Discover(pathToRepository);
      _repository = new Repository(repoPath);
    }

    public void GetFileInfo(ArticleFileInfo pathToFile)
    {
      var commit = _repository.Commits.QueryBy(pathToFile.Path).Take(1).Last().Commit;
      pathToFile.LatestUpdate = commit.Author.When;
      pathToFile.LatestAuthor = commit.Author.Name;
    }

    public void Dispose()
    {
      _repository.Dispose();
    }
  }
}