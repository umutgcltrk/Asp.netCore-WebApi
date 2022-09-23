using Microsoft.EntityFrameworkCore;

namespace apitest.Entities
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("")
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
