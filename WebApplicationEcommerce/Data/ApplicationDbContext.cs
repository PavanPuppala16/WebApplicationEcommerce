using WebApplicationEcommerce.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;

namespace WebApplicationEcommerce.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //public DbSet<Appointment> Appointments { get; set; }

        //public DbSet<Company> Companies { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<SpecialTag> SpecialTags { get; set; }
        //public DbSet<Blog> Blogs { get; set; }
        public DbSet<Products> Products { get; set; }
        //public DbSet<SubComment> SubComments { get; set; }
        //public DbSet<MyMessage> MyMessages { get; set; }
    }
}
