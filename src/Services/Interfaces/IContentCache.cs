using System.Collections.Generic;
using Application.Shared.Models;

namespace Application.Services.Interfaces
{
  public interface IContentCache
  {
    List<ArticleFileInfo> Articles { get; set; }
  }
}