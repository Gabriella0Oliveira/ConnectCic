using connect_cic_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace connect_cic_api.Infra.Persistence;

public class ConnectCICAPIContext : DbContext
{

    public ConnectCICAPIContext(DbContextOptions<ConnectCICAPIContext> options) : base(options)
      {
        Database.EnsureDeleted();
        Database.EnsureCreated();
      }

    public DbSet<User> Users { get; set; }
    public DbSet<VacancyType> VacancyTypes { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<StudentArea> StudentAreas { get; set; }
    public DbSet<StudentDiscipline> StudentDisciplines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {

    #region SqLite ConnectionString
    var StringConnection = "Data Source=CicDataBase.db";
    optionsBuilder.UseSqlite(StringConnection)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    #endregion
  }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

            # region Enities Configuration
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(c => c.UserID);
            modelBuilder.Entity<User>()
              .HasOne(u => u.Professor)
              .WithOne(a => a.User)
              .HasForeignKey<Professor>(a => a.UserID)
              .IsRequired(false);
            modelBuilder.Entity<User>()
              .HasOne(u => u.Student)
              .WithOne(a => a.User)
              .HasForeignKey<Student>(a => a.UserID)
              .IsRequired(false);

            modelBuilder.Entity<VacancyType>().ToTable("VacancyTypes");
            modelBuilder.Entity<VacancyType>().HasKey(c => c.VacancyTypeID);

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(a => a.StudentID);



            modelBuilder.Entity<Professor>().ToTable("Professors");
            modelBuilder.Entity<Professor>().HasKey(p => p.ProfessorID);
            

            modelBuilder.Entity<Vacancy>().ToTable("Vacancies");
            modelBuilder.Entity<Vacancy>().HasKey(v => v.VacancyID);
            modelBuilder.Entity<Vacancy>().HasOne(v => v.Professor).WithMany(p => p.Vacancies).HasForeignKey(v => v.ProfessorID);
            modelBuilder.Entity<Vacancy>().HasOne(v => v.VacancyType).WithMany(t => t.Vacancies).HasForeignKey(v => v.VacancyTypeID);
            modelBuilder.Entity<Vacancy>().HasMany(v => v.Students).WithMany(a => a.Vacancies);
            #endregion


            # region seed data
            modelBuilder.Entity<VacancyType>().HasData(
                new VacancyType { VacancyTypeID = 1, Name = "Estágio" },
                new VacancyType { VacancyTypeID = 2, Name = "Iniciação Cientifica" },
                new VacancyType { VacancyTypeID = 3, Name = "Iniciação a docencia" },
                new VacancyType { VacancyTypeID = 4, Name = "TCC" },
                new VacancyType { VacancyTypeID = 5, Name = "Projeto de Extensão" }
            );

            modelBuilder.Entity<Professor>().HasData(
                new Professor {
                    ProfessorID = 1, 
                    Name = "Professor Teste", 
                    Email = "professor.cic@uesc.br",
                    Department = "DCET",
                },
                new Professor { ProfessorID = 2, 
                                Name = "Helder", 
                                Email = "helder@uesc.com",
                                Department = "DCET",
                },
                new Professor { ProfessorID = 3, 
                                Name = "Martha", 
                                Email = "martinha@uesc.com",
                                Department = "DCET",
                },
                new Professor { ProfessorID = 4, 
                                Name = "Bravo", 
                                Email = "bravo@uesc.com",
                                Department = "DCET",
                }
                );
/*
            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy {
                    VacancyID = 1, 
                    Value = 0f, 
                    StartDate = DateTime.Now, 
                    EndDate = DateTime.Now.AddDays(30), 
                    Requirements = "Teste de vaga atual", 
                    Description = "Teste de vaga atual", 
                    ProjectTitle = "Projeto teste de vaga", 
                    Status = "Aberta", 
                    ProfessorID = 1, 
                    VacancyTypeID = 1
                },
                new Vacancy { VacancyID = 2, 
                            Value = 0f, 
                            StartDate = DateTime.Now.AddDays(-50), 
                            EndDate = DateTime.Now.AddDays(-10), 
                            Requirements = "Teste de vaga antiga", 
                            Description = "Teste de vaga antiga", 
                            ProjectTitle = "Projeto teste de vaga", 
                            Status = "Fechada", 
                            ProfessorID = 1, 
                            VacancyTypeID = 1
                },
                new Vacancy { VacancyID = 3, 
                            Value = 1000f, 
                            StartDate = DateTime.Now, 
                            EndDate = DateTime.Now.AddDays(10), 
                            Requirements = "Conhecimento em Java", 
                            Description = "Desenvolvimento de aplicação web", 
                            ProjectTitle = "Sistema de gerenciamento de vendas", 
                            Status = "Aberta", 
                            ProfessorID = 2, 
                            VacancyTypeID = 1
                },
                new Vacancy { VacancyID = 4, 
                            Value = 1000f, 
                            StartDate = DateTime.Now, 
                            EndDate = DateTime.Now.AddDays(40), 
                            Requirements = "Conhecimento em Java", 
                            Description = "Desenvolvimento de aplicação web", 
                            ProjectTitle = "Sistema de gerenciamento de vendas", 
                            Status = "Aberta", 
                            ProfessorID = 3, 
                            VacancyTypeID = 1
                },
                new Vacancy { VacancyID = 5, 
                            Value = 1000f, 
                            StartDate = DateTime.Now.AddDays(-10), 
                            EndDate = DateTime.Now, 
                            Requirements = "Conhecimento em Java", 
                            Description = "Desenvolvimento de aplicação web", 
                            ProjectTitle = "Sistema de gerenciamento de vendas", 
                            Status = "Aberta", 
                            ProfessorID = 4, 
                            VacancyTypeID = 2
                },
                new Vacancy { VacancyID = 6, 
                            Value = 700f, 
                            StartDate = DateTime.Now.AddDays(-10), 
                            EndDate = DateTime.Now.AddDays(30), 
                            Requirements = "Conhecimento em Java", 
                            Description = "Desenvolvimento de aplicação web", 
                            ProjectTitle = "Sistema de gerenciamento de vendas", 
                            Status = "Aberta", 
                            ProfessorID = 2, 
                            VacancyTypeID = 3
                },
                new Vacancy { VacancyID = 7, 
                            Value = 0f, 
                            StartDate = DateTime.Now, 
                            EndDate = DateTime.Now.AddDays(40), 
                            Requirements = "Conhecimento em Java", 
                            Description = "Desenvolvimento de aplicação web", 
                            ProjectTitle = "Sistema de gerenciamento de vendas", 
                            Status = "Aberta", 
                            ProfessorID = 3, 
                            VacancyTypeID = 4
                },
                new Vacancy { VacancyID = 8, 
                            Value = 1000f, 
                            StartDate = DateTime.Now, 
                            EndDate = DateTime.Now.AddDays(10), 
                            Requirements = "Conhecimento em Java", 
                            Description = "Desenvolvimento de aplicação web", 
                            ProjectTitle = "Sistema de gerenciamento de vendas", 
                            Status = "Aberta", 
                            ProfessorID = 4, 
                            VacancyTypeID = 5
                }

            ); dotnet ef migrations add Atualizandoa

*/
            modelBuilder.Entity<User>().HasData(
                  new User (1, "admin", "admin", UserRules.Admin ),
                  new User (2, "professor", "professor", UserRules.Professor, null, 1),
                  new User (3, "student", "student", UserRules.Student, 1, null)
            );
            # endregion
            // Áreas
            modelBuilder.Entity<Area>()
                .ToTable("Areas")
                .HasKey(a => a.AreaId);

            // Disciplinas
            modelBuilder.Entity<Discipline>()
                .ToTable("Disciplines")
                .HasKey(d => d.DisciplineId);

            // StudentAreas (N–N)
            modelBuilder.Entity<StudentArea>()
                .ToTable("StudentAreas")
                .HasKey(sa => new { sa.StudentId, sa.AreaId });

            modelBuilder.Entity<StudentArea>()
                .Property(sa => sa.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
                
            modelBuilder.Entity<StudentArea>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAreas)
                .HasForeignKey(sa => sa.StudentId);

            modelBuilder.Entity<StudentArea>()
                .HasOne(sa => sa.Area)
                .WithMany(a => a.StudentAreas)
                .HasForeignKey(sa => sa.AreaId);

            // StudentDisciplines (N–N c/ payload)
            modelBuilder.Entity<StudentDiscipline>()
                .ToTable("StudentDisciplines")
                .HasKey(sd => new { sd.StudentId, sd.DisciplineId });

            modelBuilder.Entity<StudentDiscipline>()
                .Property(sd => sd.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<StudentDiscipline>()
                .HasOne(sd => sd.Student)
                .WithMany(s => s.StudentDisciplines)
                .HasForeignKey(sd => sd.StudentId);

            modelBuilder.Entity<StudentDiscipline>()
                .HasOne(sd => sd.Discipline)
                .WithMany(d => d.StudentDisciplines)
                .HasForeignKey(sd => sd.DisciplineId);

      }

}
