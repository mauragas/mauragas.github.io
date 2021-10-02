using Serilog;
using PageData.Console;

var log = new LoggerConfiguration()
  .WriteTo.Console()
  .CreateLogger();

try
{
  var appConfiguration = new AppConfiguration(log, args);

#if !DEBUG
  Console.WriteLine("Press 'y' to continue.");
  if (Console.ReadKey().Key != ConsoleKey.Y)
    return;
  System.Console.WriteLine();
#endif
  var pageData = new PageData.Console.Pages(new PageData.Generator.Generator());
  await pageData.UpdateAsync(
    appConfiguration.ConfigurationOptions.PathToRepository,
    appConfiguration.ConfigurationOptions.PathToOutputFile)
      .ConfigureAwait(false);
}
catch (Exception e)
{
  log?.Fatal("Application failed: {Message}", e);
}
