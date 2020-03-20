using System.Collections.Generic;
using Application.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Application.Client.Components
{
    public class ArticlesBase : ComponentBase
    {
        [Parameter]
        public List<FileInfo> Files { get; set; }
    }
}