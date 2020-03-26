using System.Threading.Tasks;
using Application.Services;
using Application.Services.Github;
using Application.Services.Markdown;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);

      builder.Services.AddSingleton<IMarkdownParser, MarkdownParser>();
      builder.Services.AddSingleton<IGithubHandler, GithubHandler>();
      builder.Services.AddSingleton<IContentHandler, ContentHandler>();

      builder.RootComponents.Add<App>("app");

      builder.Services.AddBaseAddressHttpClient();

      await builder.Build().RunAsync();
    }
  }
}