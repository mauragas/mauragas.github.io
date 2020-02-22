using System;
using System.Net.Http;
using System.Threading.Tasks;
using Markdig;
using Markdig.Extensions.AutoIdentifiers;

namespace Application.Markdown
{
    public class MarkdownParser
    {
        private static readonly Uri BaseUri = new Uri("https://raw.githubusercontent.com/mauragas/Mauragas.github.io/articles");
        private static readonly HttpClient _httpCLient = new HttpClient();
        private readonly MarkdownPipeline _markdownPipeline;

        public MarkdownParser(HttpClient httpClient)
        {
            _markdownPipeline = GetMarkdownPipeline();
        }

        public async Task<string> ParseToHtmlAsync(string relativeUri)
        {
            var documentString = await _httpCLient.GetStringAsync(BaseUri + relativeUri);
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