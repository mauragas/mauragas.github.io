using System.Linq;
using System;
using System.IO;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Collections.Generic;
using System.Reflection;

namespace ArticleData.Console
{
  public class AppConfiguration
  {
    public Options ConfigurationOptions { get; set; }
    private readonly ILogger log;

    public AppConfiguration(ILogger logger, string[] commandLineArguments)
    {
      this.log = logger;
      SetValuesFromConfigurationFile();
      if (commandLineArguments.Length > 0)
        CombineOptions(ParseCommandArguments(commandLineArguments));

      SetDefaultValuesIfNeeded();

      this.log.Information("Configuration values:\n{@Options}", ConfigurationOptions);
    }

    private void SetValuesFromConfigurationFile()
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile(GetAppSettinsFilePath(), optional: true, reloadOnChange: true);

      var configuration = builder.Build();
      ConfigurationOptions = new Options
      {
        PathToOutputFile = configuration.GetSection(nameof(ConfigurationOptions.PathToOutputFile))?.Value,
        PathToRepository = configuration.GetSection(nameof(ConfigurationOptions.PathToRepository))?.Value,
      };
    }

    /// <summary>
    /// While debugging returns ./bin/Debug/netcoreapp3.1/appsettings.json
    /// After installation /usr/share/ArticleData/appsettings.json
    /// </summary>
    private static string GetAppSettinsFilePath() => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "appsettings.json");

    private Options ParseCommandArguments(string[] commandLineArguments)
    {
      Options parsedArguments = null;
      _ = Parser.Default.ParseArguments<Options>(commandLineArguments)
          .WithParsed(options => parsedArguments = options)
          .WithNotParsed(errors => HandleParseError(errors));

      if (parsedArguments is null)
      {
        this.log.Error("Failed to parse command arguments.");
        Environment.Exit(0);
      }

      return parsedArguments;
    }

    /// <summary>
    /// In case of errors or --help or --version
    /// </summary>
    private void HandleParseError(IEnumerable<Error> errors)
    {
      if (!errors.Any(e => e is HelpRequestedError || e is VersionRequestedError))
        this.log.Error("Failed to parse command line arguments {ErrorTags}", errors.Select(e => e.Tag));
      Environment.Exit(0);
    }

    private void CombineOptions(Options parsedArguments)
    {
      if (!string.IsNullOrWhiteSpace(parsedArguments.PathToRepository))
        ConfigurationOptions.PathToRepository = parsedArguments.PathToRepository;

      if (!string.IsNullOrWhiteSpace(parsedArguments.PathToOutputFile))
        ConfigurationOptions.PathToOutputFile = parsedArguments.PathToOutputFile;
    }

    private void SetDefaultValuesIfNeeded()
    {
      if (string.IsNullOrWhiteSpace(ConfigurationOptions.PathToOutputFile))
        ConfigurationOptions.PathToOutputFile = Path.Combine(Directory.GetCurrentDirectory(), "articles.json");
      if (string.IsNullOrWhiteSpace(ConfigurationOptions.PathToRepository))
        ConfigurationOptions.PathToRepository = Directory.GetCurrentDirectory();
    }
  }
}
