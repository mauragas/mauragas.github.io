using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using ColorCode;
using ColorCode.Styling;

namespace Application.Services.MarkdigParser.SyntaxHighlighting;

public class HighlightedCodeBlockRenderer : CodeBlockRenderer
{
  private readonly StyleDictionary style;
  private readonly bool inlineCss;

  public HighlightedCodeBlockRenderer(StyleDictionary style, bool inlineCss)
    : base()
  {
    this.style = style;
    this.inlineCss = inlineCss;
  }

  protected override void Write(HtmlRenderer renderer, CodeBlock codeBlock)
  {
    if (codeBlock is FencedCodeBlock fencedCodeBlock &&
      Languages.FindById(fencedCodeBlock.Info) is ILanguage codelanguage)
    {
      _ = renderer.Write(GetColorizedCode(codelanguage, GetCodeContent(fencedCodeBlock)));
      return;
    }
    base.Write(renderer, codeBlock);
  }

  private static string GetCodeContent(LeafBlock block)
  {
    var slice = block.Lines.ToSlice();
    return slice.Text.Substring(slice.Start, slice.Length);
  }

  private string GetColorizedCode(ILanguage language, string code) => this.inlineCss ?
      new HtmlFormatter(this.style).GetHtmlString(code, language) :
      new HtmlClassFormatter(this.style).GetHtmlString(code, language);
};
