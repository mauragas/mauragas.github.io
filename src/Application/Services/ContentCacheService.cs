using Application.Shared.Models;
using Application.Services.Interfaces;

namespace Application.Services;

public class ContentCacheService : IContentCache
{
  public List<PageFileInfo> Pages { get; set; }

  private readonly IPageRepository repository;

  public ContentCacheService(IPageRepository pageRepository) =>
    this.repository = pageRepository;

  public async Task InitializeAsync() =>
    Pages = await this.repository?.GetAllPagesAsync();
}
