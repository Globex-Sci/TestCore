using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TestCore.Models;
using TestCore.Data;

namespace TestCore.Controllers
{
    public class SyncController : Controller
    {

        private IOptions<AppSettings> _settings;

        private readonly ApplicationDbContext _context;

        public SyncController(IOptions<AppSettings> settings, ApplicationDbContext context)
        {
            _settings = settings;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var nodes = _settings.Value.Nodes;
            int synced = 0;

            var allNodesArticles = new List<Article>();

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = "api/articles";

            foreach (var node in nodes)
            {
                httpClient.BaseAddress = new Uri(node.Uri);

                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                var articles = JsonConvert.DeserializeObject<List<Article>>(result);

                allNodesArticles.AddRange(articles);
            }

            var uniqueArticles = allNodesArticles.Distinct();

            foreach (var article in uniqueArticles)
            {
                if(!ArticleExists(article.ArticleHash))
                {
                    _context.Articles.Add(article);
                    await _context.SaveChangesAsync();

                    synced++;
                }
            }

            return View(synced);
        }

        private bool ArticleExists(string id)
        {
            return _context.Articles.Any(e => e.ArticleHash == id);
        }
    }
}