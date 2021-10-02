using Serilog;

namespace PageData.Console
{
  internal static class Program
  {
    private static ILogger log;
    private static AppConfiguration appConfiguration;

    private static async Task Main(string[] args)
    {
      log = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

      try
      {
        appConfiguration = new AppConfiguration(log, args);

#if !DEBUG
        System.Console.WriteLine("Press 'y' to continue.");
        if (System.Console.ReadKey().Key != ConsoleKey.Y)
          return;
        System.Console.WriteLine();
#endif
        var pageData = new Pages(new Generator.Generator());
        await pageData.UpdateAsync(
          appConfiguration.ConfigurationOptions.PathToRepository,
          appConfiguration.ConfigurationOptions.PathToOutputFile)
            .ConfigureAwait(false);
      }
      catch (Exception e)
      {
        log?.Fatal("Application failed: {Message}", e);
      }
    }
  }
}
