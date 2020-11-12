namespace Application.Services.Interfaces
{
  public interface IMarkdownParser
  {
    string ParseContentToHtml(string content);
  }
}
