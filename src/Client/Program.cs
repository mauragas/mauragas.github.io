using System.Threading.Tasks;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);

      builder.Services.AddSingleton<IMarkdownParser, MarkdigParserService>();
      builder.Services.AddSingleton<IArticleRepository, GithubRepositoryService>();
      builder.Services.AddSingleton<IContentHandler, ContentHandlerService>();

      builder.RootComponents.Add<App>("app");

      builder.Services.AddBaseAddressHttpClient();

      await builder.Build().RunAsync();
    }
  }
}