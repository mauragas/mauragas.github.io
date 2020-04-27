using System.Threading.Tasks;
using ArticleData.Generator;

namespace ArticleData.Console
{
  public class Articles
  {
    private readonly IGenerator _generator;
    public Articles(IGenerator generator)
    {
      _generator = generator;
    }
    public async Task UpdateAsync()
    {
      var articles = await _generator.GetArticlesAsync();

    }
  }
}