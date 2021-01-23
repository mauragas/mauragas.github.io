using CommandLine;

namespace PageData.Console
{
  public class Options
  {
    [Option('r', nameof(PathToRepository), HelpText = "Local workstation path to repository.", Required = false)]
    public string PathToRepository { get; set; }

    [Option('o', nameof(PathToOutputFile), HelpText = "Path to output JSON file on local workstation.", Required = false)]
    public string PathToOutputFile { get; set; }
  }
}
