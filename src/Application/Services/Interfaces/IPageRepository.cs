using Application.Shared.Models;

namespace Application.Services.Interfaces
{
  public interface IPageRepository
  {
    Task<string> GetPageContentAsync(string pathToFile);
    Task<List<PageFileInfo>> GetAllPagesAsync();
  }
}
