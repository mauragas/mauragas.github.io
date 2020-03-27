using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Shared.Models;

namespace Application.Services.Interfaces
{
  public interface IArticleRepository
  {
    Task<List<ArticleFileInfo>> GetArticlesAsync(string pathToFolder);
    Task<string> GetArticleContentAsync(string pathToFile);
    Task<List<ArticleFileInfo>> GetAllArticlesAsync();
  }
}