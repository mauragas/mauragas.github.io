using System.Collections.Generic;
using Application.Services.Github;
using Application.Shared.Models;
using System.Threading.Tasks;

namespace Application.Services
{
  public class ContentHandler : IContentHandler
  {
    public string ReadmeFileContent { get; set; }
    public List<ArticleFileInfo> Articles { get; set; }

    private IGithubHandler _githubHandler;

    public ContentHandler(IGithubHandler githubHandler = default)
    {
      Articles = new List<ArticleFileInfo>();
      _githubHandler = githubHandler;
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