using Microsoft.EntityFrameworkCore;

namespace WebApplicationEcommerce.Models
{
    public class DataBasedbContext:DbContext
    {
        public DataBasedbContext()
        {

        }
        public DataBasedbContext(DbContextOptions<DataBasedbContext> options) : base(options)
        {

        }

        public virtual DbSet<Products> PRODUCT { get; set; }

    }
}
