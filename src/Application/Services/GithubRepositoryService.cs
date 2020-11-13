using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Shared.Models;
using System.Text.Json;

namespace Application.Services
{
  public class GithubRepositoryService : IArticleRepository
  {
    private Uri urlToArticleInfoFile;
    private Uri rootUrl;
    private readonly HttpClient httpClient;

    public GithubRepositoryService(HttpClient client) => this.httpClient = client;

    public void Initialize(string rootUrl, string articleInfoFileName)
    {
      this.rootUrl = new Uri(rootUrl);
      this.urlToArticleInfoFile = new Uri(this.rootUrl, articleInfoFileName);
    }

    public async Task<List<ArticleFileInfo>> GetAllArticlesAsync()
    {
      var result = await this.httpClient.GetStringAsync(this.urlToArticleInfoFile.AbsoluteUri).ConfigureAwait(false);
      return JsonSerializer.Deserialize<List<ArticleFileInfo>>(result);
    }

    public async Task<string> GetArticleContentAsync(string pathToFile) =>
      await this.httpClient.GetStringAsync(new Uri(this.rootUrl, pathToFile)).ConfigureAwait(false);
  }
}
