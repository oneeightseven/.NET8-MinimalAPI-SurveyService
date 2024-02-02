using Microsoft.EntityFrameworkCore;

namespace Testov.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
       
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Result> Results { get; set; }
    
    public virtual DbSet<Survey> Surveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("answers_pkey");

            entity.ToTable("answers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Questionid).HasColumnName("questionid");
        });

        
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("questions_pkey");

            entity.ToTable("questions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Surveyid).HasColumnName("surveyid");
        });

        modelBuilder.Entity<Question>().Navigation(e => e.Survey).AutoInclude(false);

        
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("results_pkey");

            entity.ToTable("results");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answerid).HasColumnName("answerid");
            entity.Property(e => e.Interviewsession)
                .HasMaxLength(50)
                .HasColumnName("interviewsession");
            entity.Property(e => e.Questionid).HasColumnName("questionid");
            entity.Property(e => e.Surveyid).HasColumnName("surveyid");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("survey_pkey");

            entity.ToTable("survey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
