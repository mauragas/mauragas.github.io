using System.Collections.Generic;
using Application.Services.Github;
using Application.Shared.Models;
using System.Threading.Tasks;

namespace Application.Services
{
  public class ContentHandler : IContentHandler
  {
    public string ReadmeFileContent { get; set; }
    public List<FileInfo> Articles { get; set; }

    private IGithubHandler _githubHandler;

    public ContentHandler()
    {
      Articles = new List<FileInfo>();
      _githubHandler = new GithubHandler();
    }
    public async Task AddArticlesAsync(string folderName)
    {
      Articles.AddRange(await _githubHandler?.GetArticlesAsync(folderName));
    }

    public async Task SetReadmeAsync()
    {
      ReadmeFileContent = await _githubHandler.GetArticleContentAsync("README.md");
    }
  }
}