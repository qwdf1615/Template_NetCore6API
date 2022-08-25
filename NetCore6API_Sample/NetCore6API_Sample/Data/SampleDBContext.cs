using Microsoft.EntityFrameworkCore;
using NetCore6API_Sample.Models;

namespace NetCore6API_Sample.Data
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
        {

        }

        public DbSet<TblItem> TblItems { get; set; }
    }
}
