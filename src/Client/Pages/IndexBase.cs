using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Application.Client.Pages
{
  public class IndexBase : ComponentBase
  {
    internal string MarkDownDocument { get; set; }

    [Inject]
    internal IJSRuntime JSRuntime { get; set; }

    [Inject]
    internal IMarkdownParser MarkdownParser { get; set; }

    [Inject]
    internal IArticleRepository Repository { get; set; }

    [Inject]
    internal IContentCache ContentCache { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await JSRuntime.InvokeVoidAsync("setTitle", ".NET on Linux");
      var fileName = "README.md";
      var readmeFile = ContentCache.Articles.First(a => a.FileName == fileName);
      if (string.IsNullOrWhiteSpace(readmeFile.Content))
        readmeFile.Content = await Repository.GetArticleContentAsync(fileName);
      MarkDownDocument = MarkdownParser.ParseContentToHtml(readmeFile.Content);
    }
  }
}