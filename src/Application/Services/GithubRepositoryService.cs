using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Shared.Models;
using System.Text.Json;

namespace Application.Services
{
  public class GithubRepositoryService : IPageRepository
  {
    private Uri urlToPageInfoFile;
    private Uri rootUrl;
    private readonly HttpClient httpClient;

    public GithubRepositoryService(HttpClient client) => this.httpClient = client;

    public void Initialize(string rootUrl, string pageInfoFileName)
    {
      this.rootUrl = new Uri(rootUrl);
      this.urlToPageInfoFile = new Uri(this.rootUrl, pageInfoFileName);
    }

    public async Task<List<PageFileInfo>> GetAllPagesAsync()
    {
      var result = await this.httpClient.GetStringAsync(this.urlToPageInfoFile.AbsoluteUri).ConfigureAwait(false);
      return JsonSerializer.Deserialize<List<PageFileInfo>>(result);
    }

    public async Task<string> GetPageContentAsync(string pathToFile) =>
      await this.httpClient.GetStringAsync(new Uri(this.rootUrl, pathToFile)).ConfigureAwait(false);
  }
}
