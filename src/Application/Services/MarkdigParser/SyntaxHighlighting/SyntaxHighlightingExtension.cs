using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using ColorCode.Styling;

namespace Application.Services.MarkdigParser.SyntaxHighlighting
{
  public class SyntaxHighlightingExtension : IMarkdownExtension
  {
    private readonly StyleDictionary style;
    private readonly bool inlineCss;

    public SyntaxHighlightingExtension(StyleDictionary styles, bool inlineCss)
    {
      this.style = styles;
      this.inlineCss = inlineCss;
    }

    public void Setup(MarkdownPipelineBuilder pipeline) { }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer) =>
      renderer.ObjectRenderers.ReplaceOrAdd<CodeBlockRenderer>(
        new HighlightedCodeBlockRenderer(this.style, this.inlineCss));
  }
}
