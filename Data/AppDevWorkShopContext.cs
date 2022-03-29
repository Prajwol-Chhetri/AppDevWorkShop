#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppDevWorkShop.Models;

namespace AppDevWorkShop.Data
{
    public class AppDevWorkShopContext : DbContext
    {
        public AppDevWorkShopContext (DbContextOptions<AppDevWorkShopContext> options)
            : base(options)
        {
        }

        public DbSet<AppDevWorkShop.Models.Bike> Bike { get; set; }
    }
}
