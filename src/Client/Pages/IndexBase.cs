using System.Threading.Tasks;
using Application.Services;
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
    internal ContentService ContentHandler { get; set; }

    [Inject]
    internal IMarkdownParser MarkdownParser { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await JSRuntime.InvokeVoidAsync("setTitle", ".NET on Linux");
      MarkDownDocument = MarkdownParser.ParseContentToHtml(ContentHandler.ReadmeFileContent);
    }
  }
}