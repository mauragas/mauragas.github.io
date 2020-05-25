using System.Collections.Generic;
using Application.Shared.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;

namespace Application.Services
{
  public class ContentCacheService : IContentCache
  {
    public List<ArticleFileInfo> Articles { get; set; }

    private readonly IArticleRepository _repository;

    public ContentCacheService(IArticleRepository articleRepository)
    {
      _repository = articleRepository;
    }

    public async Task InitializeAsync()
    {
      Articles = await _repository?.GetAllArticlesAsync();
    }
  }
}