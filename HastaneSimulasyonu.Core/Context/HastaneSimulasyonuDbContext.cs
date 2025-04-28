using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HastaneSimulasyonu.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HastaneSimulasyonu.Core.Context
{
    public class HastaneSimulasyonuDbContext : DbContext
    {
        public DbSet<Bolum> Bolum { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Hasta> Hasta { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DENIZ\\SQLEXPRESS;Database=HastaneSimulasyonuDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}