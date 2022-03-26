using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TShirt.Models;
namespace TShirt.Data
{
  

    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> context) : base(context)
        {
          
        }
        public DbSet<Shirt> Shirts { get; set; }

      
    }
}
