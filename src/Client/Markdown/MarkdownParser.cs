using ColorCode.Styling;
using Markdig;
using Markdig.Extensions.AutoIdentifiers;

namespace Application.Client.Markdown
{
  public class MarkdownParser
  {
    private readonly MarkdownPipeline _markdownPipeline;

    public MarkdownParser()
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