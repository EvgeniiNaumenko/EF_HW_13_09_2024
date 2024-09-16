using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_009_13_09_2024
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-C317JNM;Database=HWTrainAndStation;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
