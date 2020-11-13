using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Application.Client.Pages
{
  public class DotnetBase : ComponentBase
  {
    internal List<ArticleFileInfo> ArticleFiles { get; set; }

    [Inject]
    internal IJSRuntime JSRuntime { get; set; }

    [Inject]
    internal IContentCache ContentCache { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await JSRuntime.InvokeVoidAsync("setTitle", ".NET");
      ArticleFiles = ContentCache.Articles.Where(a => a.Path == "dotnet")
        .ToList();
    }
  }
}
