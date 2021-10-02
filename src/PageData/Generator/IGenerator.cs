using Application.Shared.Models;

namespace PageData.Generator;

public interface IGenerator
{
  List<PageFileInfo> GetPages(string path);
}
