using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using ColorCode;
using ColorCode.Styling;

namespace Application.Services.Markdown.SyntaxHighlighting
{
  public class HighlightedCodeBlockRenderer : CodeBlockRenderer
  {
    private readonly StyleDictionary _style;
    private readonly bool _inlineCss;

    public HighlightedCodeBlockRenderer(StyleDictionary style, bool inlineCss) : base()
    {
      _style = style;
      _inlineCss = inlineCss;
    }

    protected override void Write(HtmlRenderer renderer, CodeBlock codeBlock)
    {
      if (codeBlock is FencedCodeBlock fencedCodeBlock &&
          Languages.FindById(fencedCodeBlock.Info) is ILanguage codelanguage)
      {
        renderer.Write(GetColorizedCode(codelanguage, GetCodeContent(fencedCodeBlock)));
        return;
      }
      base.Write(renderer, codeBlock);
    }

    private string GetCodeContent(LeafBlock block)
    {
      var slice = block.Lines.ToSlice();
      return slice.Text.Substring(slice.Start, slice.Length);
    }

    private string GetColorizedCode(ILanguage language, string code)
    {
      return _inlineCss ?
          new HtmlFormatter(_style).GetHtmlString(code, language) :
          new HtmlClassFormatter(_style).GetHtmlString(code, language);
    }
  };
}