using System.Globalization;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Application.Client.Pages
{
  public partial class Page
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
    internal IPageRepository Repository { get; set; }

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
      var cashedPage = ContentCache.Pages
        ?.FirstOrDefault(a => a.Path == FolderName && a.FileName == FileName);
      var pathToFile = System.IO.Path.Combine(FolderName, FileName + ".md");
      if (string.IsNullOrWhiteSpace(cashedPage.Content))
        cashedPage.Content = await Repository.GetPageContentAsync(pathToFile).ConfigureAwait(false);
      return MarkdownParser.ParseContentToHtml(cashedPage.Content);
    }
  }
}
