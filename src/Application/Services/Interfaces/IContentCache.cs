using Application.Shared.Models;

namespace Application.Services.Interfaces
{
  public interface IContentCache
  {
    List<PageFileInfo> Pages { get; set; }
  }
}
