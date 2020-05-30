using System;

namespace Application.Shared.Models
{
  public class ArticleFileInfo
  {
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public DateTimeOffset LatestUpdate { get; set; }
    public string LatestAuthor { get; set; }
    public string PictureUrl { get; set; }
  }
}