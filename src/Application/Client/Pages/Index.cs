using Application.Services.Interfaces;
using Application.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Application.Client.Pages
{
  public partial class Index
  {
    internal List<PageFileInfo> PageFiles { get; set; }

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
      await JSRuntime.InvokeVoidAsync("setTitle", ".NET on Linux");
      PageFiles = ContentCache.Pages;
    }
  }
}
