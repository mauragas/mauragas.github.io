using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Shared.Models;

namespace ArticleData.Generator
{
  public interface IGenerator
  {
    Task<List<ArticleFileInfo>> GetArticlesAsync();
    Task<string> GetArticleContentAsync(string name);
  }
}