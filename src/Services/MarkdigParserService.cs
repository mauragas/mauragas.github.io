using Application.Services.Interfaces;
using ColorCode.Styling;
using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using Application.Services.MarkdigParser;

namespace Application.Services
{
  public class MarkdigParserService : IMarkdownParser
  {
    private readonly MarkdownPipeline _markdownPipeline;

    public MarkdigParserService()
    {
      _markdownPipeline = GetMarkdownPipeline();
    }

    public string ParseContentToHtml(string content)
    {
      return Markdig.Markdown.ToHtml(content, _markdownPipeline);
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
        .UseSyntaxHighlighting(StyleDictionary.DefaultLight, true)
        .Build();
    }
  }
}