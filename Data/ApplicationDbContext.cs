using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Models;

namespace TiendaOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<SpecialTag> specialTags { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ApplicationUser> user { get; set; }
        public DbSet<Slider> Slider { get; set; }
  
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Carrito> Carrito { get; set; }


    }
}
