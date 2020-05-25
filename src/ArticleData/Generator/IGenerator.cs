using System.Collections.Generic;
using Application.Shared.Models;

namespace ArticleData.Generator
{
  public interface IGenerator
  {
    List<ArticleFileInfo> GetArticles(string path);
  }
}