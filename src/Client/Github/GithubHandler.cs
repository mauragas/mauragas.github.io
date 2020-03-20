using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Client.Extensions;
using Application.Shared.Models;

namespace Application.Client.Github
{
    public class GithubHandler
    {
        public string BranchName { get; set; } = "articles";

        private Application.Github.Github _github;
        private string _fileExtension;

        public GithubHandler()
        {
            _fileExtension = ".md";
            _github = new Application.Github.Github("mauragas", "Mauragas.github.io");
        }

        public async Task<List<FileInfo>> GetArticlesAsync(string pathToFolder)
        {
            var files = await _github.GetFiles(pathToFolder, BranchName, _fileExtension);

            var parallelTasks = files.Select(file => Task.Run(async () =>
            {
                file.Content = await _github.GetFileContent(file.GithubPath, BranchName);
                file.Title = file.Content.GetTitle();
                file.Description = file.Content.GetDescription();
            }));

            await Task.WhenAll(parallelTasks);

            return files;
        }

        public async Task<string> GetArticleContentAsync(string pathToFile)
        {
            return await _github.GetFileContent(pathToFile, BranchName);
        }
    }
}