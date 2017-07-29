using Microsoft.EntityFrameworkCore;
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
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TESTLibraryCategory>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Childs)
                        .HasForeignKey(x => x.PID).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
    }
}
