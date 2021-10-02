using PageData.Generator;
using System.Text.Json;

namespace PageData.Console
{
  public class Pages
  {
    private readonly IGenerator generator;
    public Pages(IGenerator generator) => this.generator = generator;
    public async Task UpdateAsync(string rootPath, string fileName)
    {
      var pages = this.generator.GetPages(rootPath);

      var options = new JsonSerializerOptions
      {
        WriteIndented = true,
      };

      using var fileStream = File.Create(fileName);
      await JsonSerializer.SerializeAsync(fileStream, pages, options).ConfigureAwait(false);
    }
  }
}
