using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;
using FileInfo = Application.Shared.Models.FileInfo;

namespace Application.Github
{
  public class Github
  {
    private string _repositoryOwner;
    private string _repositoryName;

    private readonly IGitHubClient _githubClient;

    public Github(string repositoryOwner, string repositoryName)
    {
      _repositoryOwner = repositoryOwner;
      _repositoryName = repositoryName;

      var clientAdapter = new HttpClientAdapter(() => GetHttpMessageHandler());
      var connection = new Connection(new ProductHeaderValue(repositoryOwner), clientAdapter);
      _githubClient = new GitHubClient(connection);
    }

    public async Task<List<FileInfo>> GetFiles(string path, string branchName, string fileExtension)
    {
      try
      {
        var allContent = await _githubClient.Repository.Content
            .GetAllContentsByRef(_repositoryOwner, _repositoryName, path, branchName);
        var filesFromGithub = allContent
            .Where(f => f.Type == ContentType.File &&
                        Path.GetExtension(f.Name) == fileExtension)
            .ToList();

        return filesFromGithub.Select(f => new FileInfo
        {
          FileName = f.Name,
          DownloadUrl = f.DownloadUrl,
          GithubPath = f.Path,
          Content = f.Content
        }).ToList();
      }
      catch (Exception e)
      {
        throw new FileNotFoundException("Failed to retrieve files from " +
                                        $"{_repositoryName} repository " +
                                        $"{branchName} branch. {e}");
      }
    }

    public async Task<string> GetFileContent(string filePath, string branchName)
    {
      try
      {
        var files = await _githubClient.Repository.Content
            .GetAllContentsByRef(_repositoryOwner, _repositoryName, filePath, branchName);
        return files.FirstOrDefault()?.Content;
      }
      catch (Exception e)
      {
        throw new FileNotFoundException($"Could not find {filePath} from " +
                                        $"{_repositoryName} repository " +
                                        $"{branchName} branch. {e}");
      }
    }

    private HttpMessageHandler GetHttpMessageHandler()
    {
      var handler = new HttpClientHandler();
      if (handler.SupportsAutomaticDecompression)
        handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
      return handler;
    }
  }
}