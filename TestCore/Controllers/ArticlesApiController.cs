using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCore.Data;
using TestCore.Models;
using System;

namespace TestCore.Controllers
{
    [Produces("application/json")]
    [Route("api/articles")]
    public class ArticlesApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/articles
        [HttpGet]
        public IQueryable<Article> GetArticles()
        {
            return _context.Articles.Where(a => a.IsReview == false);
        }

        // GET: api/articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ArticleHash == id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // POST: api/article
        [HttpPost]
        public async Task<IActionResult> PostArticle([FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            article.ArticleHash = Guid.NewGuid().ToString();
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            await _context.Blocks.AddAsync(new Block
            {
                Hash = Guid.NewGuid().ToString(),
                PreviousBlockHash = Guid.NewGuid().ToString()
            });

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.ArticleHash}, article);
        }


        private bool ArticleExists(string id)
        {
            return _context.Articles.Any(e => e.ArticleHash== id);
        }
    }
}