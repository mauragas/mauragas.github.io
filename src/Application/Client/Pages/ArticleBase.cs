using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Application.Client.Pages
{
  public class ArticleBase : ComponentBase
  {
    public string MarkupDocument { get; set; }

    [Parameter]
    public string FolderName { get; set; }

    [Parameter]
    public string FileName { get; set; }

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
      var title = CultureInfo.CurrentCulture.TextInfo
        .ToTitleCase(FileName.Replace('-', ' ')
        .Replace(".md", string.Empty));
      await JSRuntime.InvokeVoidAsync("setTitle", title);
      MarkupDocument = await GetMarkupDocument().ConfigureAwait(false);
    }

    internal async Task<string> GetMarkupDocument()
    {
      var cashedArticle = ContentCache.Articles
        ?.FirstOrDefault(a => a.Path == FolderName && a.FileName == FileName);
      var pathToFile = System.IO.Path.Combine(FolderName, FileName);
      if (string.IsNullOrWhiteSpace(cashedArticle.Content))
        cashedArticle.Content = await Repository.GetArticleContentAsync(pathToFile).ConfigureAwait(false);
      return MarkdownParser.ParseContentToHtml(cashedArticle.Content);
    }
  }
}
