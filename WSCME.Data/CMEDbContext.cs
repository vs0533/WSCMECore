using Microsoft.EntityFrameworkCore;
using WSCME.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSCME.Data
{
    public class CMEDbContext :  DbContext
    {
        
        public DbSet<Person> Person { get; set; }
        public DbSet<ExamSubject> ExamSubject { get; set; }
        public DbSet<ProfessionalTitle> ProfessionalTitle { get; set; }
        public DbSet<ProfessionalTitleCategory> ProfessionalTitleCategory { get; set; }
        public DbSet<ProfessionalTitleLevel> ProfessionalTitleLevel { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<ExamSubjectAndProfessionalTitleCategory> ExamSubjectAndProfessionalTitleCategory { get; set; }



        public DbSet<TrainingCentre> TrainingCentre { get; set; }
        public DbSet<TrainingCentreType> TrainingCentreType { get; set; }
        public DbSet<TrainingCentreCategory> TrainingCentreCategory { get; set; }
        public DbSet<TrainingCentreAndType> TrainingCentreAndType { get; set; }
		public DbSet<TrainingCentreAndCategory> TrainingCentreAndCategory { get; set; }
        public DbSet<TrainingCentreAccount> TrainingCentreAccount { get; set; }
        

        public DbSet<RegisterPoint> RegisterPoint { get; set; }
        public DbSet<RegisterPointAccount> RegisterPointAccount { get; set; }

        public DbSet<ExamRoom> ExamRoom { get; set; }
        public DbSet<ExamPoint> ExamPoint { get; set; }
        public DbSet<ExamRoomPlant> ExamRoomPlant { get; set; }

        public DbSet<AdmissionTicket> AdmissionTicket { get; set; }

        public DbSet<PersonExamResult> PersonExamResult { get; set; }
        public DbSet<PersonExamSubjectPass> PersonExamSubjectPass { get; set; }
        public DbSet<PersonRegister> PersonRegister { get; set; }
        public DbSet<PersonRegisterForUnit> PersonRegisterForUnit { get; set; }
        public DbSet<PersonRegisterForUnitDetails> PersonRegisterForUnitDetails { get; set; }
        public DbSet<PersonWallet> PersonWallet { get; set; }
        public DbSet<PersonWalletNote> PersonWalletNote { get; set; }
        public DbSet<UnitNature> UnitNature { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UnitAccount> UnitAccount { get; set; }




        public CMEDbContext(DbContextOptions<CMEDbContext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonExamResult>()
                        .HasOne(d=>d.ExamRoomPlant)
                        .WithMany(d=>d.PersonExamResult)
                        .HasForeignKey(d=>d.ExamRoomPlantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonExamSubjectPass>()
                        .HasOne(d => d.PersonExamResult)
                        .WithOne(d => d.ExamSubjectPass).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamRoomPlant>()
                        .HasOne(d => d.ExamPoint)
                        .WithMany(d => d.ExamRoomPlants)
                        .HasForeignKey(d=>d.ExamPointId).OnDelete(DeleteBehavior.Restrict);




            base.OnModelCreating(modelBuilder);
        }
    }

    public class CMEDBContextFactory : IDbContextFactory<CMEDbContext>
    {
        public CMEDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMEDbContext>();
            optionsBuilder.UseSqlServer("server=192.168.4.107;uid=sa;pwd=Abc@123;database=CMEDB");
            return new CMEDbContext(optionsBuilder.Options);
        }
    }

}
