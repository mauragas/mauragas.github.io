using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Application.Client.Pages
{
  public class LinuxBase : ComponentBase
  {
    internal List<ArticleFileInfo> ArticleFiles { get; set; }

    [Inject]
    internal IJSRuntime JSRuntime { get; set; }

    [Inject]
    internal ContentService ContentHandler { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await JSRuntime.InvokeVoidAsync("setTitle", "Linux");

      var folderName = "linux";

      ArticleFiles = ContentHandler.Articles.Where(a => a.FolderName == folderName)
        .ToList();
    }
  }
}