using System.ComponentModel.DataAnnotations;

namespace TestCore.Models
{
    public class Article
    {
        [Key]
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
