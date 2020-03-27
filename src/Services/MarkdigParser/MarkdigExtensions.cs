using Markdig;
using ColorCode.Styling;
using Application.Services.MarkdigParser.SyntaxHighlighting;

namespace Application.Services.MarkdigParser
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