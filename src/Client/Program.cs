using System.Threading.Tasks;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Application.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      AddServicesToDependencyContainer(builder);
      builder.RootComponents.Add<App>("app");
      builder.Services.AddBaseAddressHttpClient();
      var host = builder.Build();
      await InitializeServicesAsync(host);
      await host.RunAsync();
    }

    private static void AddServicesToDependencyContainer(WebAssemblyHostBuilder builder)
    {
      builder.Services.AddSingleton<IMarkdownParser, MarkdigParserService>();
      builder.Services.AddSingleton<IArticleRepository, GithubRepositoryService>();
      builder.Services.AddSingleton<IContentCache, ContentCacheService>();
    }


    private static async Task InitializeServicesAsync(WebAssemblyHost host)
    {
      var httpClient = host.Services.GetRequiredService<HttpClient>();
      var repositoryService = host.Services.GetRequiredService<IArticleRepository>();
      (repositoryService as GithubRepositoryService).Initialize(
        "https://raw.githubusercontent.com/mauragas/Mauragas.github.io/articles/",
        "articles.json");

      var contentHandler = host.Services.GetRequiredService<IContentCache>();
      await (contentHandler as ContentCacheService).InitializeAsync();
    }
  }
}