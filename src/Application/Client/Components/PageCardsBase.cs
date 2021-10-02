using Application.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Application.Client.Components;

public class PageCardsBase : ComponentBase
{
  [Parameter]
  public List<PageFileInfo> PageFiles { get; set; }
}
