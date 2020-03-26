using System.Collections.Generic;
using Application.Shared.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;

namespace Application.Services
{
  public class ContentHandlerService : IContentHandler
  {
    public string ReadmeFileContent { get; set; }
    public List<ArticleFileInfo> Articles { get; set; }

    private IArticleRepository _githubHandler;

    public ContentHandlerService(IArticleRepository githubHandler = default)
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