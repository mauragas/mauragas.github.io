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

#if !DEBUG
        System.Console.WriteLine("Press 'y' to continue.");
        if (System.Console.ReadKey().Key != ConsoleKey.Y)
            return;
        System.Console.WriteLine();
#endif
        var articleData = new Articles(new Generator.Generator());
        await articleData.UpdateAsync(
          _appConfiguration.ConfigurationOptions.PathToRepository,
          _appConfiguration.ConfigurationOptions.PathToOutputFile)
          .ConfigureAwait(false);
      }
      catch (Exception e)
      {
        _log?.Fatal("Application failed: {Message}", e);
      }
    }
  }
}