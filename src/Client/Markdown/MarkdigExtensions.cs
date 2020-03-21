using Markdig;
using ColorCode.Styling;
using Application.Client.Markdown.SyntaxHighlighting;

namespace Application.Client.Markdown
{
  public static class MarkdigExtensions
  {
    public static MarkdownPipelineBuilder UseSyntaxHighlighting(
        this MarkdownPipelineBuilder pipeline,
        StyleDictionary style,
        bool inlineCss)
    {
      pipeline.Extensions.Add(new SyntaxHighlightingExtension(style, inlineCss));
      return pipeline;
    }
  }
}