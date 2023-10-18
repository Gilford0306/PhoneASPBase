using Microsoft.EntityFrameworkCore;

namespace PhoneASPBase.Controllers
{
    public class PhoneContext: DbContext
    {
        public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
        {

        }
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().OwnsOne(typeof(Brand), "Brand");
        }

    }
}
