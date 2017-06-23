using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WSCME.Domain;
namespace WSCME.Data
{
    public class CMEDbContext:DbContext
    {
        public DbSet<TrainingCentre> TrainingCentres { get; set; }
        public DbSet<TrainingCentreType> TrainingCentreTypes { get; set; }
        public DbSet<TrainingCentreCategory> TrainingCentreCategorys { get; set; }
        public CMEDbContext(DbContextOptions<CMEDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
