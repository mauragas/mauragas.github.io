using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Shared.Models;
using Octokit;
using Octokit.Internal;

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

    public async Task<List<ArticleFileInfo>> GetArticleFiles(string path, string branchName, string fileExtension)
    {
      try
      {
        var allContent = await _githubClient.Repository.Content
            .GetAllContentsByRef(_repositoryOwner, _repositoryName, path, branchName);
        var filesFromGithub = allContent
            .Where(f => f.Type == ContentType.File &&
                        Path.GetExtension(f.Name) == fileExtension)
            .ToList();
            
        return filesFromGithub.Select(f => new ArticleFileInfo
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

    public async Task<List<ArticleFileInfo>> GetAllArticleFilesAsync(string branchName, string fileExtension)
    {
      try
      {
        var archive = await _githubClient.Repository.Content
             .GetArchive(_repositoryOwner, _repositoryName, ArchiveFormat.Zipball, branchName);

        using (var memoryStream = new MemoryStream(archive))
        using (var zipArchive = new ZipArchive(memoryStream))
        {
          return zipArchive.Entries
              .Where(file => Path.GetExtension(file.Name) == fileExtension)
              .Select(file => new ArticleFileInfo
              {
                FileName = file.Name,
                FolderName = GetFolderName(file),
                GithubPath = GetGithubPath(file),
                Content = GetContent(file)
              }).ToList();
        }
      }
      catch (Exception e)
      {
        throw new FileNotFoundException("Failed to retrieve files from " +
                                        $"{_repositoryName} repository " +
                                        $"{branchName} branch. {e}");
      }
    }

    public async Task<string> GetArticleFileContent(string filePath, string branchName)
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

    private static string GetFolderName(ZipArchiveEntry file)
    {
      var folderName = file.FullName.Split('/')[1];
      if (folderName == file.Name)
        return string.Empty;
      return folderName;
    }

    private static string GetContent(ZipArchiveEntry file)
    {
      return new StreamReader(file.Open()).ReadToEnd();
    }

    private static string GetGithubPath(ZipArchiveEntry file)
    {
      return file.FullName.Substring(file.FullName.IndexOf("/") + 1);
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