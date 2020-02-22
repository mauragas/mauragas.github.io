using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using System.Threading.Tasks;
using System.Net.Http;

namespace Application.Markdown
{
    public class MarkdownParser
    {
        private readonly MarkdownPipeline _markdownPipeline;
        private readonly HttpClient _httpCLient;

        public MarkdownParser(HttpClient httpClient)
        {
            _markdownPipeline = GetMarkdownPipeline();
            _httpCLient = httpClient;
        }

        public async Task<string> ParseToHtmlAsync(string path)
        {
            var documentString = await _httpCLient.GetStringAsync(path);
            return Markdig.Markdown.ToHtml(documentString, _markdownPipeline);
        }

        private MarkdownPipeline GetMarkdownPipeline()
        {
            return new MarkdownPipelineBuilder()
                        .UseAbbreviations()
                        .UseAdvancedExtensions()
                        .UseAutoIdentifiers(AutoIdentifierOptions.GitHub)
                        .UseAutoLinks()
                        .UseBootstrap()
                        .UseCitations()
                        .UseCustomContainers()
                        .UseDefinitionLists()
                        .UseDiagrams()
                        .UseEmojiAndSmiley(true)
                        .UseEmphasisExtras()
                        .UseFigures()
                        .UseFooters()
                        .UseFootnotes()
                        .UseGenericAttributes()
                        .UseGlobalization()
                        .UseGridTables()
                        .UseListExtras()
                        .UseMathematics()
                        .UseMediaLinks()
                        .UseNoFollowLinks()
                        .UsePipeTables()
                        .UsePragmaLines()
                        .UsePreciseSourceLocation()
                        .UseSmartyPants()
                        .UseSoftlineBreakAsHardlineBreak()
                        .UseTaskLists()
                        .UseYamlFrontMatter()
                        //.UseSyntaxHighlighting() // TODO Install extension when supported https://github.com/RichardSlater/Markdig.SyntaxHighlighting
                        .Build();
        }
    }
}