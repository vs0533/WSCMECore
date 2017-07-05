using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WSCME.Domain;
namespace WSCME.Data
{
    public class CMEDbContext : DbContext
    {
        public DbSet<TrainingCentre> TrainingCentre { get; set; }
        public DbSet<TrainingCentreType> TrainingCentreType { get; set; }
        public DbSet<TrainingCentreCategory> TrainingCentreCategory { get; set; }
        public DbSet<TrainingCentreAndType> TrainingCentreAndType { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;uid=sa;pwd=Abc@123;database=CMEDB");
        }
        //public CMEDbContext(DbContextOptions<CMEDbContext> options) : base(options)
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
