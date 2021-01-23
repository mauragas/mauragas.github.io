using System;
using System.Collections.Generic;
using System.IO;
using Application.Shared.Models;

namespace PageData.Generator
{
  public class Generator : IGenerator
  {
    public List<PageFileInfo> GetPages(string path)
    {
      path = Path.GetFullPath(path);
      if (!Directory.Exists(path))
        path = Path.GetDirectoryName(path);

      var pageFiles = GetPages(path, ".md");
      _ = pageFiles.Remove(pageFiles.Find(a => a.FileName.StartsWith("README")));
      var gitClient = new GitClient(path);
      var rootFolder = path.Replace(gitClient.RootPathToRepository, string.Empty);
      foreach (var file in pageFiles)
        gitClient.GetFileInfo(file, rootFolder);
      return pageFiles;
    }

    private static List<PageFileInfo> GetPages(string path, string fileExtension)
    {
      var pages = new List<PageFileInfo>();
      var directory = new DirectoryInfo(path);
      var searchPattern = "*" + fileExtension;
      foreach (var file in directory.GetFiles(searchPattern, SearchOption.AllDirectories))
      {
        var content = file.OpenText().ReadToEnd();
        pages.Add(new PageFileInfo
        {
          FileName = file.Name.Replace(fileExtension, string.Empty),
          FileExtension = fileExtension,
          Path = file.FullName.Replace($"{path}/", string.Empty).Replace($"/{file.Name}", string.Empty),
          Description = GetDescription(content),
          Title = GetTitle(content),
          PictureUrl = GetPictureUrl(content),
          Content = string.Empty
        });
      }
      return pages;
    }

    private static string GetTitle(string content)
    {
      using (var reader = new StringReader(content))
      {
        var line = reader.ReadLine()?.Trim();
        while (line != null)
        {
          if (!line.StartsWith('#'))
          {
            line = reader.ReadLine()?.Trim();
            continue;
          }
          return line.Replace("#", string.Empty).Trim();
        }
      }
      return string.Empty;
    }

    private static string GetDescription(string content)
    {
      using (var reader = new StringReader(content))
      {
        var line = reader.ReadLine()?.Trim();
        while (line != null)
        {
          if (string.IsNullOrWhiteSpace(line) ||
            line.StartsWith('#') ||
            line.StartsWith('!') ||
            line.StartsWith('['))
          {
            line = reader.ReadLine()?.Trim();
            continue;
          }
          return line;
        }
      }
      return string.Empty;
    }

    private static string GetPictureUrl(string content)
    {
      using (var reader = new StringReader(content))
      {
        var line = reader.ReadLine()?.Trim();
        while (line != null)
        {
          if (line.StartsWith("![") || line.StartsWith("[!["))
          {
            var url = GetUrl(line);
            if (!string.IsNullOrWhiteSpace(url))
              return url;
          }
          line = reader.ReadLine();
        }
      }
      return string.Empty;
    }

    private static string GetUrl(string line)
    {
      var startIndex = line.IndexOf('(');
      var length = line.IndexOf(')') - startIndex - 1;
      var url = line.Substring(startIndex + 1, length);

      if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
        return url;

      return string.Empty;
    }
  }
}
