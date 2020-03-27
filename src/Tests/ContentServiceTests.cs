using NUnit.Framework;
using Application.Github;
using Application.Services;

namespace Tests
{
  public class ContentServiceTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async System.Threading.Tasks.Task Test1Async()
    {
      var contentService = new ContentService();
      var githubRepositoryService = new GithubRepositoryService();
      await contentService.InitializeAsync(githubRepositoryService);

      var files = contentService.Articles;

      Assert.Pass();
    }
  }
}