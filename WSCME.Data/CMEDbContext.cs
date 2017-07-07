using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WSCME.Domain;
namespace WSCME.Data
{
    public class CMEDbContext : DbContext
    {
        public DbSet<TrainingCentre> TrainingCentre { get; set; }
        public DbSet<TrainingCentreType> TrainingCentreType { get; set; }
        public DbSet<TrainingCentreCategory> TrainingCentreCategory { get; set; }
        public DbSet<TrainingCentreAndType> TrainingCentreAndType { get; set; }
		public DbSet<TrainingCentreAndCategory> TrainingCentreAndCategory { get; set; }
        public DbSet<TrainingCentreAccount> TrainingCentreAccount { get; set; }

        public DbSet<TESTLibraryCategory> TESTLibraryCategory { get; set; }
        public DbSet<TESTLibrary> TESTLibrary { get; set; }

        public DbSet<RegisterPoint> RegisterPoint { get; set; }
        public DbSet<RegisterPointAccount> RegisterPointAccount { get; set; }

        public DbSet<ExamRoom> ExamRoom { get; set; }
        public DbSet<ExamPoint> ExamPoint { get; set; }
        public DbSet<ExamRoomPlant> ExamRoomPlant { get; set; }

        public DbSet<AdmissionTicket> AdmissionTicket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=192.168.0.112;uid=sa;pwd=Abc@123;database=CMEDB");
        }
        //public CMEDbContext(DbContextOptions<CMEDbContext> options) : base(options)
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TESTLibraryCategory>()
                        .HasOne(x => x.Category)
                        .WithMany(x => x.Childs)
                        .HasForeignKey(x=>x.PID).OnDelete(DeleteBehavior.Restrict);
            
            base.OnModelCreating(modelBuilder);
        }

        public virtual async void Commit()
        {
            await base.SaveChangesAsync();
        }
    }
}
