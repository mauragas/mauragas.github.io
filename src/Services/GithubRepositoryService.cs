using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Shared.Models;

namespace Application.Services
{
  public class GithubRepositoryService : IArticleRepository
  {
    public string BranchName { get; set; }

    private Application.Github.Github _github;
    private string _fileExtension;

    public GithubRepositoryService(string branchName = "articles")
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
        file.Title = GetTitle(file.Content);
        file.Description = GetDescription(file.Content);
      }));

      await Task.WhenAll(parallelTasks);

      return files;
    }

    public async Task<string> GetArticleContentAsync(string pathToFile)
    {
      return await _github.GetArticleFileContent(pathToFile, BranchName);
    }

    private static string GetTitle(string content)
    {
      using (var reader = new System.IO.StringReader(content))
      {
        var line = reader.ReadLine()?.Trim();
        while (line != null)
        {
          if (!line.StartsWith('#'))
          {
            line = reader.ReadLine();
            continue;
          }
          return line.Replace("#", string.Empty).Trim();
        }
      }
      return string.Empty;
    }

    private static string GetDescription(string content)
    {
      using (var reader = new System.IO.StringReader(content))
      {
        var line = reader.ReadLine()?.Trim();
        while (line != null)
        {
          if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
          {
            line = reader.ReadLine();
            continue;
          }
          return line.Trim();
        }
      }
      return string.Empty;
    }
  }
}