using System.Collections.Generic;
using Application.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Application.Client.Components
{
  public class ArticleCardsBase : ComponentBase
  {
    [Parameter]
    public List<ArticleFileInfo> ArticleFiles { get; set; }
  }
}