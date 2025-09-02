using Microsoft.EntityFrameworkCore;
using MyQuiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Infrastructure.AllContexts
{
    public class QuizDemoAppContext : DbContext
    {
        public QuizDemoAppContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Sys_SystemCodeType> SystemCodeTypes { get; set; }
        public DbSet<Sys_SystemCode> SystemCodes { get; set; }
        public DbSet<Lk_Question> Questions { get; set; }
        public DbSet<Lk_Choice> Choices { get; set; }
        public DbSet<Lk_Quiz> Quizzes { get; set; }
        public DbSet<Lk_QuizQuestion> QuizQuestions { get; set; }
        public DbSet<Tr_QuizStudent> QuizStudents { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lk_Question>(entity =>
            {
                entity.ToTable("Lk_Question", "Operation");
                entity.Property(e => e.Id);
                entity.Property(e => e.QuestionName).IsRequired().HasMaxLength(500);
                entity.Property(e => e.SysCodeQuestionTypeId).IsRequired();
                entity.Property(e => e.SysCodeQuestionLevelId).IsRequired();
                entity.Property(e => e.Points).IsRequired();
            });

            modelBuilder.Entity<Lk_Choice>(entity =>
            {
                entity.ToTable("QuestionChoice", "Operation");
                entity.Property(e => e.Id);
                entity.Property(e => e.ChoisName).IsRequired().HasMaxLength(500);
                entity.Property(e => e.IsCorrect).IsRequired();
                entity.Property(e => e.QuestionId).IsRequired();

            });

            modelBuilder.Entity<Lk_Quiz>(entity =>
            {
                entity.ToTable("Lk_Quiz", "Operation");
                entity.Property(e => e.Id);
                entity.Property(e => e.QuizName).IsRequired().HasMaxLength(300);
                entity.Property(e => e.StartDateTime).IsRequired();
                entity.Property(e => e.EndDateTime).IsRequired();
                entity.Property(e => e.DurationMinutes).IsRequired();
            });

            modelBuilder.Entity<Lk_QuizQuestion>(entity =>
            {
                entity.ToTable("Lk_QuizQuestion", "Operation");
                entity.Property(e => e.Id);
                entity.Property(e => e.QuizId).IsRequired();
                entity.Property(e => e.QuestionId).IsRequired();

            });

            modelBuilder.Entity<Tr_QuizStudent>(entity =>
            {
                entity.ToTable("Tr_QuizStudent", "Operation");
                entity.Property(e => e.Id);
                entity.Property(e => e.QuizId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();

            });





            modelBuilder.Entity<Sys_SystemCodeType>().HasData(
               new Sys_SystemCodeType { Id = 1, SystemCodeTypeName = "Question Level", SystemCodeTypeDescription = "Question Level Simple medium or Hard" },
               new Sys_SystemCodeType { Id = 2, SystemCodeTypeName = "Question Type", SystemCodeTypeDescription = "Question Type " }

            );

            modelBuilder.Entity<Sys_SystemCode>().HasData(

                      new Sys_SystemCode { Id = 1, SystemCodeName = "Basic", SystemCodeTypeId = 1 },
                      new Sys_SystemCode { Id = 2, SystemCodeName = "Intermediate", SystemCodeTypeId = 1 },
                      new Sys_SystemCode { Id = 3, SystemCodeName = "Advanced", SystemCodeTypeId = 1 },
                      new Sys_SystemCode { Id = 4, SystemCodeName = "True Or False", SystemCodeTypeId = 2 },
                      new Sys_SystemCode { Id = 5, SystemCodeName = "Single Choice", SystemCodeTypeId = 2 },
                      new Sys_SystemCode { Id = 6, SystemCodeName = "Multi Choice", SystemCodeTypeId = 2 }
            );
        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Properties.Any(p => p.Metadata.Name == "CreatedBy"))
                    {
                        entry.Property("CreatedBy").CurrentValue = 1;
                    }

                    if (entry.Properties.Any(p => p.Metadata.Name == "CreatedDate"))
                    {
                        entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Properties.Any(p => p.Metadata.Name == "LastModifiedBy"))
                    {
                        entry.Property("LastModifiedBy").CurrentValue = 1;
                    }
                    if (entry.Properties.Any(p => p.Metadata.Name == "LastModifiedDate"))
                    {
                        entry.Property("LastModifiedDate").CurrentValue = DateTime.Now;
                    }
                    if (entry.Properties.Any(p => p.Metadata.Name == "CreatedBy"))
                    {
                        entry.Property("CreatedBy").IsModified = false;
                    }
                    if (entry.Properties.Any(p => p.Metadata.Name == "CreatedDate"))
                    {
                        entry.Property("CreatedDate").IsModified = false;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
