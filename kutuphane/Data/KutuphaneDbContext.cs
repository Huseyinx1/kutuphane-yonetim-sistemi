using Microsoft.EntityFrameworkCore;
using kutuphane.Models;

namespace kutuphane.Data
{
    public class KutuphaneDbContext : DbContext
    {
        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tur> Turler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Odunc> Oduncler { get; set; }
        public DbSet<KitapTur> KitapTurler { get; set; }
        public DbSet<KitapYazar> KitapYazarlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // KitapTur composite primary key
            modelBuilder.Entity<KitapTur>()
                .HasKey(kt => new { kt.kitapNo, kt.turNo });

            // KitapTur relationships
            modelBuilder.Entity<KitapTur>()
                .HasOne(kt => kt.Kitap)
                .WithMany(k => k.KitapTurler)
                .HasForeignKey(kt => kt.kitapNo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KitapTur>()
                .HasOne(kt => kt.Tur)
                .WithMany(t => t.KitapTurler)
                .HasForeignKey(kt => kt.turNo)
                .OnDelete(DeleteBehavior.Cascade);

            // KitapYazar relationships
            modelBuilder.Entity<KitapYazar>()
                .HasOne(ky => ky.Kitap)
                .WithMany(k => k.KitapYazarlar)
                .HasForeignKey(ky => ky.kitapNo)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KitapYazar>()
                .HasOne(ky => ky.Yazar)
                .WithMany(y => y.KitapYazarlar)
                .HasForeignKey(ky => ky.yazarNo)
                .OnDelete(DeleteBehavior.Cascade);

            // Odunc relationships
            modelBuilder.Entity<Odunc>()
                .HasOne(o => o.Kitap)
                .WithMany(k => k.Oduncler)
                .HasForeignKey(o => o.kitapNo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Odunc>()
                .HasOne(o => o.Uye)
                .WithMany(u => u.Oduncler)
                .HasForeignKey(o => o.uyeNo)
                .OnDelete(DeleteBehavior.Restrict);

            // Table names to match ERD
            modelBuilder.Entity<Tur>().ToTable("tur");
            modelBuilder.Entity<Kitap>().ToTable("Kitap");
            modelBuilder.Entity<Yazar>().ToTable("yazar");
            modelBuilder.Entity<Uye>().ToTable("uye");
            modelBuilder.Entity<Odunc>().ToTable("odunc");
            modelBuilder.Entity<KitapTur>().ToTable("kitap_tur");
            modelBuilder.Entity<KitapYazar>().ToTable("kitap_yazar");
        }
    }
}
