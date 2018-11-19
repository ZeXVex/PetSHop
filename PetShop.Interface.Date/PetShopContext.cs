using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetShop.Interface.Date
{
    public class PetShopContext : DBInitialiser
    {

        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {    }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PreviousOwner)
                .WithMany(o => o.Pets)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Pet> Pets { get; set; }
        
        public DbSet<Owner> Owners { get; set; }
        
        public DbSet<User> Users { get; set; }
    }
}