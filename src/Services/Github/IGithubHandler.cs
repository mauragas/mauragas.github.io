using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Shared.Models;

namespace Application.Services.Github
{
  public interface IGithubHandler
  {
    Task<List<FileInfo>> GetArticlesAsync(string pathToFolder);
    Task<string> GetArticleContentAsync(string pathToFile);
  }
}