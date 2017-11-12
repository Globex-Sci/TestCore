using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore.Data
{
    public class DataInitializer
    {
        public static async Task Seed(ApplicationDbContext serviceProvider)
        {
            await SeedGenesisBlock(serviceProvider);
            //await SeedArticles(serviceProvider);
        }

        private static async Task SeedGenesisBlock(ApplicationDbContext dbContext)
        {
            if (!dbContext.Blocks.Any())
            {
                await dbContext.Blocks.AddAsync(new Block
                {
                    Hash = "1",
                    PreviousBlockHash = "0"
                });
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedArticles(ApplicationDbContext dbContext)
        {
            if (!dbContext.Articles.Any())
            {
                dbContext.Articles.Add(new Article
                {
                    ArticleHash = "0",
                    Title = "КВАРТЕТ ИЗ КВАРКОВ",
                    Text = "Все известные на сегодня элементарные частицы состоят либо из одного кварка и одного антикварка, либо из трех кварков. Частицы с другой кварковой структурой теорией не запрещены, однако установить их существование экспериментально пока никому не удавалось. Одним из первых сюрпризов в ходе изучения огромного массива данных, полученных с помощью детектора \"Belle\" на ускорительно-накопительном комплексе KEKB (Япония), стало обнаружение частиц с экзотической четырехкварковой структурой. Как по соотношению масс кварков, так и по характеру связей между ними эти частицы более всего напоминают молекулу водорода, состоящую из двух связанных атомов. \"Молекулярная\" модель, предложенная российскими физиками, предсказывает существование целого ряда схожих многокварковых систем, которые станут объектом исследования нового направления в квантовой физике."
                });

                dbContext.Articles.Add(new Article
                {
                    ArticleHash = "1",
                    ReviewedArticleHash = "0",
                    IsReview = true,
                    ReviewedArticleMark = 5
                });

                dbContext.Articles.Add(new Article
                {
                    ArticleHash = "2",
                    ReviewedArticleHash = "0",
                    IsReview = true,
                    ReviewedArticleMark = 6
                });

            }
            dbContext.SaveChanges();
        }
    }
}
