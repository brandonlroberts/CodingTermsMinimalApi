using Microsoft.EntityFrameworkCore;
using CodingTermsMinimalApi.Models;

namespace CodingTermsMinimalApi.Dal.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Term> Terms { get; set; }
    }
}
