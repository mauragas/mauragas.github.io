using Application.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Application.Client.Components
{
  public class ArticleBase : ComponentBase
  {
    [Parameter]
    public FileInfo FileInfo { get; set; }
  }
}