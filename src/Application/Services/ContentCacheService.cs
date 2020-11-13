using System.Collections.Generic;
using Application.Shared.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;

namespace Application.Services
{
  public class ContentCacheService : IContentCache
  {
    public List<ArticleFileInfo> Articles { get; set; }

    private readonly IArticleRepository repository;

    public ContentCacheService(IArticleRepository articleRepository) =>
      this.repository = articleRepository;

    public async Task InitializeAsync() =>
      Articles = await this.repository?.GetAllArticlesAsync();
  }
}
