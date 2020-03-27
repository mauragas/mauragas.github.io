using System.Collections.Generic;
using Application.Shared.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using System.Linq;

namespace Application.Services
{
  public class ContentService
  {
    public string ReadmeFileContent { get; set; }
    public List<ArticleFileInfo> Articles { get; set; }

    public async Task InitializeAsync(IArticleRepository articleRepository)
    {
      var allArticles = await articleRepository?.GetAllArticlesAsync();
      ReadmeFileContent = "test";
      ReadmeFileContent = allArticles.FirstOrDefault()?.Content;
      Articles = allArticles.Where(a => !string.IsNullOrWhiteSpace(a.FolderName))
        .ToList();
    }
  }
}