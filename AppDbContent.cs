using EmptyTemplateWebApiJwtAuthPsql.Models;
using Microsoft.EntityFrameworkCore;

namespace EmptyTemplateWebApiJwtAuthPsql
{
    public class AppDbContent: DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<TestData> Tests { get; set; } = null!;
    }
}