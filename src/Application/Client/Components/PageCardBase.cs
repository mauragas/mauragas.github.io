using Application.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Application.Client.Components;

public class PageCardBase : ComponentBase
{
  [Parameter]
  public PageFileInfo PageFileInfo { get; set; }
}
