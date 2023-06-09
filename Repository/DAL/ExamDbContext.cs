using DomainModels.Models.ExamModel;
using Microsoft.EntityFrameworkCore;

namespace Repository.DAL
{

    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasKey(s => s.StudentNumber);

            builder.Entity<Subject>()
                .HasKey(s => s.SubjectCode);

            builder.Entity<Exam>()
                .HasKey(e => new { e.StudentNumber, e.SubjectCode });

            builder.Entity<Exam>()
                .HasOne(e => e.Subject)
                .WithMany(s => s.Exams)
                .HasForeignKey(e => e.SubjectCode)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Exam>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Exams)
                .HasForeignKey(e => e.StudentNumber)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}


