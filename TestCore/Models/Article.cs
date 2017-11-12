using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.Models
{
    public class Article
    {
        public string ArticleHash { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsReview { get; set; }
        public string ReviewedArticleHash { get; set; }
        public int ReviewedArticleMark { get; set; }

        // ToDo
        // AuthorIdHash
        // TimeStamp
        // List<ArticleHash> LinksToArticles
        // List<ArticleHash> LinksToThisArticle
    }
}
