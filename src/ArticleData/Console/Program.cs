using System;
using System.Threading.Tasks;
using Serilog;

namespace ArticleData.Console
{
  internal static class Program
  {
    private static ILogger _log;
    private static AppConfiguration _appConfiguration;

    private static async Task Main(string[] args)
    {
      _log = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

      try
      {
        _appConfiguration = new AppConfiguration(_log, args);

        string repoPath = Environment.CurrentDirectory;
        var generator = new Generator.Generator();
        var articleData = new Articles(generator);
        await articleData.UpdateAsync(
          _appConfiguration.ConfigurationOptions.PathToRepository,
          _appConfiguration.ConfigurationOptions.PathToOutputFile)
          .ConfigureAwait(false);
      }
      catch (Exception e)
      {
        _log?.Fatal("Application failed: {Message}", e.Message);
        _log?.Verbose(e, "Application failed with unhandled exception.");
      }
    }
  }
}