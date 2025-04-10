using Microsoft.EntityFrameworkCore;
using StarrailAssist.Models.Entities;

namespace StarrailAssist.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<LightCone> LightCones { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountCharacter> AccountCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountCharacter>(ac => ac.HasKey(k => new { k.AccountId, k.CharacterId }));
            modelBuilder.Entity<AccountCharacter>().HasOne(db => db.Account).WithMany(db => db.AccountCharacters).HasForeignKey(fk => fk.AccountId);
            modelBuilder.Entity<AccountCharacter>().HasOne(db => db.Character).WithMany(db => db.AccountCharacters).HasForeignKey(fk => fk.CharacterId);
        }
    }
}
