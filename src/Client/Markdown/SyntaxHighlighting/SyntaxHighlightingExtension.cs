using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using ColorCode.Styling;

namespace Application.Client.Markdown.SyntaxHighlighting
{
    public class SyntaxHighlightingExtension : IMarkdownExtension
    {
        private readonly StyleDictionary _style;
        private readonly bool _inlineCss;

        public SyntaxHighlightingExtension(StyleDictionary styles, bool inlineCss)
        {
            _style = styles;
            _inlineCss = inlineCss;
        }

        public void Setup(MarkdownPipelineBuilder pipeline) { }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            renderer.ObjectRenderers.ReplaceOrAdd<CodeBlockRenderer>(
                new HighlightedCodeBlockRenderer(_style,_inlineCss));
        }
    }
}