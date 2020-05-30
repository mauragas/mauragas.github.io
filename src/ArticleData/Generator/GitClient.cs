using Application.Shared.Models;
using System;
using System.Linq;
using LibGit2Sharp;

namespace ArticleData.Generator
{
  public class GitClient : IDisposable
  {
    private readonly Repository _repository;

    public GitClient(string pathToRepository)
    {
      string repoPath = Repository.Discover(pathToRepository);
      _repository = new Repository(repoPath);
    }

    public void GetFileInfo(ArticleFileInfo articleFileInfo)
    {
      var commit = _repository.Commits.QueryBy(articleFileInfo.Path).Take(1).Last().Commit;
      articleFileInfo.LatestUpdate = commit.Author.When;
      articleFileInfo.LatestAuthor = commit.Author.Name;
    }

    public void Dispose()
    {
      _repository.Dispose();
    }
  }
}