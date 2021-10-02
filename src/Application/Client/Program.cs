using Application.Services.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Application.Client;

public static class Program
{
  public static async Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    AddServicesToDependencyContainer(builder);
    builder.RootComponents.Add<App>("app");
    _ = builder.Services.AddTransient(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    var host = builder.Build();
    await InitializeServicesAsync(host).ConfigureAwait(false);
    await host.RunAsync().ConfigureAwait(false);
  }

  private static void AddServicesToDependencyContainer(WebAssemblyHostBuilder builder) =>
    builder.Services
      .AddSingleton<IMarkdownParser, MarkdigParserService>()
      .AddSingleton<IPageRepository, GithubRepositoryService>()
      .AddSingleton<IContentCache, ContentCacheService>();

  private static async Task InitializeServicesAsync(WebAssemblyHost host)
  {
    var repositoryService = host.Services.GetRequiredService<IPageRepository>();
    (repositoryService as GithubRepositoryService)?.Initialize(
      "https://raw.githubusercontent.com/mauragas/mauragas.github.io/md-pages/",
      "pages.json");

    var contentHandler = host.Services.GetRequiredService<IContentCache>() as ContentCacheService;
    await contentHandler.InitializeAsync().ConfigureAwait(false);
  }
}
