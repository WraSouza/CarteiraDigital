using CarteiraDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDigital.Infrastructure.Persistence
{
    public class CarteiraDbContext : DbContext
    {
        public CarteiraDbContext(DbContextOptions<CarteiraDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);

                u.HasMany(u => u.WalletUser)
                          .WithOne(u => u.User)
                          .HasForeignKey(u => u.IdUser)
                          .OnDelete(DeleteBehavior.Restrict);                         
                
                        
            });

            builder
                .Entity<Wallet>(b =>
                {
                    b.HasKey(u => u.Id);

                    b.HasOne(u => u.User)
                             .WithMany(b => b.WalletUser)
                             .HasForeignKey(c => c.IdUser)
                             .OnDelete(DeleteBehavior.Restrict);


                });

            base.OnModelCreating(builder);
        }
    }
}
