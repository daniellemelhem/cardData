using cardData.Models;
using Microsoft.EntityFrameworkCore;

namespace cardData.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions <DataContext>options): base(options)
        {

        }
       
        public DbSet<Card> Cards { get; set; }

    }
}

