using System.Threading.Tasks;
using ArticleData.Generator;

namespace ArticleData.Console
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var generator = new GithubDataGenerator();
      var articleData = new Articles(generator);
      await articleData.UpdateAsync();
    }
  }
}