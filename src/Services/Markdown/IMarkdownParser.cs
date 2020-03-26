namespace Application.Services.Markdown
{
  public interface IMarkdownParser
  {
    string ParseContentToHtml(string content);
  }
}