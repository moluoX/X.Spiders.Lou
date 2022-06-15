using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Spiders.Lou.Data.Models;

namespace X.Spiders.Lou.Data
{
    public class SpiderDbContext : DbContext
    {
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        
        public SpiderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Config> Configs { get; set; }

        public DbSet<LouPan> LouPans { get; set; }

        public DbSet<LouDong> LouDongs { get; set; }

        public DbSet<TaoFang> TaoFangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LouPan>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<LouPan>().Property(x => x.Price).HasPrecision(18, 4);
            modelBuilder.Entity<LouPan>().Property(x => x.Area).HasPrecision(18, 4);
            modelBuilder.Entity<LouPan>().Property(x => x.BuildingArea).HasPrecision(18, 4);
            modelBuilder.Entity<LouPan>().Property(x => x.LvHuaRate).HasPrecision(18, 4);
            modelBuilder.Entity<LouPan>().Property(x => x.RongJiRate).HasPrecision(18, 4);

            modelBuilder.Entity<LouDong>().Property(x => x.Area).HasPrecision(18, 4);
            modelBuilder.Entity<LouDong>().HasOne(x => x.LouPan).WithMany(x => x.LouDongs);

            modelBuilder.Entity<TaoFang>().Property(x => x.BuildingArea).HasPrecision(18, 4);
            modelBuilder.Entity<TaoFang>().Property(x => x.GongTanArea).HasPrecision(18, 4);
            modelBuilder.Entity<TaoFang>().Property(x => x.TaoNeiArea).HasPrecision(18, 4);
            modelBuilder.Entity<TaoFang>().HasOne(x => x.LouDong).WithMany(x => x.TaoFangs);
        }
    }
}
