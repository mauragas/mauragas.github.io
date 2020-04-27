using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared.Models;
using ArticleData.Github;

namespace ArticleData.Generator
{
  public class GithubDataGenerator : IGenerator
  {
    public string BranchName { get; set; } = "articles";

    private GithubRepository _github;
    private string _fileExtension;

    public GithubDataGenerator()
    {
      _fileExtension = ".md";
      _github = new GithubRepository("mauragas", "Mauragas.github.io");
    }

    public async Task<List<ArticleFileInfo>> GetArticlesAsync()
    {
      var files = await _github.GetFiles(BranchName, _fileExtension);

      var parallelTasks = files.Select(file => Task.Run(async () =>
      {
        file.Content = await _github.GetFileContent($"{file.Path}/{file.FileName}", BranchName);
        file.Title = GetTitle(file.Content);
        file.Description = GetDescription(file.Content);
      }));

      await Task.WhenAll(parallelTasks);

      return files;
    }

    public async Task<string> GetArticleContentAsync(string pathName)
    {
      return await _github.GetFileContent(pathName, BranchName);
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