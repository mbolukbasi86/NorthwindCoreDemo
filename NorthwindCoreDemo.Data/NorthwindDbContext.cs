using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCoreDemo.Data
{
    public class NorthwindDbContext:DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> contextOptions): base(contextOptions)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);
        }
    }
}
