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
        }

        private static async Task SeedGenesisBlock(ApplicationDbContext dbContext)
        {
            if (!dbContext.Blocks.Any())
            {
                await dbContext.Blocks.AddAsync(new Block
                {
                    Article = null,
                    Hash = "1",
                    PreviousBlockHash = "0"
                });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
