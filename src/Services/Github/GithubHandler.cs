using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Extensions;
using Application.Shared.Models;

namespace Application.Services.Github
{
  public class GithubHandler : IGithubHandler
  {
    public string BranchName { get; set; }

    private Application.Github.Github _github;
    private string _fileExtension;

    public GithubHandler(string branchName = "articles")
    {
      BranchName = branchName;
      _fileExtension = ".md";
      _github = new Application.Github.Github("mauragas", "Mauragas.github.io");
    }

    public async Task<List<ArticleFileInfo>> GetArticlesAsync(string pathToFolder)
    {
      var files = await _github.GetArticleFiles(pathToFolder, BranchName, _fileExtension);

      var parallelTasks = files.Select(file => Task.Run(async () =>
      {
        file.FolderName = pathToFolder;
        file.Content = await _github.GetArticleFileContent(file.GithubPath, BranchName);
        file.Title = file.Content.GetTitle();
        file.Description = file.Content.GetDescription();
      }));

      await Task.WhenAll(parallelTasks);

      return files;
    }

    public async Task<string> GetArticleContentAsync(string pathToFile)
    {
      return await _github.GetArticleFileContent(pathToFile, BranchName);
    }
  }
}