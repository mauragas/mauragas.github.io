using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Shared.Models;

namespace Application.Services
{
  public interface IContentHandler
  {
    string ReadmeFileContent { get; set; }
    List<ArticleFileInfo> Articles { get; set; }
    Task AddArticlesAsync(string folderName);
    Task SetReadmeAsync();
  }
}