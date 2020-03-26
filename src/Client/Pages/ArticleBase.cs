using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Services.Github;
using Application.Services.Markdown;
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
    internal IGithubHandler GithubHandler { get; set; }

    [Inject]
    internal IContentHandler ContentHandler { get; set; }

    protected override async Task OnInitializedAsync()
    {
      var title = CultureInfo.CurrentCulture.TextInfo
        .ToTitleCase(FileName.Replace('-', ' ')
        .Replace(".md", string.Empty));
      await JSRuntime.InvokeVoidAsync("setTitle", title);
      MarkupDocument = await GetMarkupDocument();
    }

    internal async Task<string> GetMarkupDocument()
    {
      var cashedArticle = ContentHandler.Articles
        .FirstOrDefault(a => a.FolderName == FolderName && a.FileName == FileName);
      var content = cashedArticle is null
        ? await GithubHandler.GetArticleContentAsync($"{FolderName}/{FileName}")
        : cashedArticle.Content;
      return MarkdownParser.ParseContentToHtml(content);
    }
  }
}