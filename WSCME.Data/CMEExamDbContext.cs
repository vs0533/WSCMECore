using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using WSCME.Domain;

namespace WSCME.Data
{
    public class CMEExamDbContext:DbContext
    {
        public DbSet<TESTLibrary> TESTLibrary { get; set; }
        public DbSet<TESTLibraryAndCategory> TESTLibraryAndCategory { get; set; }
        public DbSet<TESTLibraryCategory> TESTLibraryCategory { get; set; }

        public CMEExamDbContext(DbContextOptions<CMEExamDbContext> options):base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TESTLibraryCategory>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Childs)
                        .HasForeignKey(x => x.PID).OnDelete(DeleteBehavior.Restrict);
            
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CMEExamDbContextFactory : IDbContextFactory<CMEExamDbContext>
    {
        public CMEExamDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMEExamDbContext>();
            optionsBuilder.UseSqlServer("server=192.168.1.120;uid=sa;pwd=Abc@123;database=CMEDB_Exam");
            return new CMEExamDbContext(optionsBuilder.Options);
        }
    }
}
