using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Application.Services
{
  public class GithubRepositoryService : IArticleRepository
  {
    private Uri _urlToArticleInfoFile;
    private Uri _rootUrl;
    private HttpClient _httpClient;

    public GithubRepositoryService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public void Initialize(string rootUrl, string articleInfoFileName)
    {
      _rootUrl = new Uri(rootUrl);
      _urlToArticleInfoFile = new Uri(_rootUrl, articleInfoFileName);
    }

    public async Task<List<ArticleFileInfo>> GetAllArticlesAsync()
    {
      return await _httpClient.GetJsonAsync<List<ArticleFileInfo>>(_urlToArticleInfoFile.AbsoluteUri);
    }

    public async Task<string> GetArticleContentAsync(string pathToFile)
    {
      return await _httpClient.GetStringAsync(new Uri(_rootUrl, pathToFile));
    }
  }
}