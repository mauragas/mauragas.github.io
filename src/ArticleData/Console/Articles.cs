using System.Threading.Tasks;
using ArticleData.Generator;
using System.Text.Json;
using System.IO;

namespace ArticleData.Console
{
  public class Articles
  {
    private readonly IGenerator _generator;
    public Articles(IGenerator generator)
    {
      _generator = generator;
    }
    public async Task UpdateAsync(string rootPath, string fileName)
    {
      var articles = _generator.GetArticles(rootPath);

      var options = new JsonSerializerOptions
      {
        WriteIndented = true,
      };

      using var fileStream = File.Create(fileName);
      await JsonSerializer.SerializeAsync(fileStream, articles, options).ConfigureAwait(false);
    }
  }
}