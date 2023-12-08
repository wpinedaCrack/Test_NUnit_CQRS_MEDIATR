using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducacionDbContext : DbContext
    {
        public EducacionDbContext()
        {    }

        public EducacionDbContext(DbContextOptions<EducacionDbContext> options) : base(options)
        {   }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer("Server=.;database=Education;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(c => c.Precio)
                .HasPrecision(14,2);

            modelBuilder.Entity<Curso>().HasData( 
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion="Curso de C# Basico",
                    Titulo="C# desde cero hasta avanzado",
                    FechaCreacion=DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 56
                }            
            );

            modelBuilder.Entity<Curso>().HasData(
               new Curso
               {
                   CursoId = Guid.NewGuid(),
                   Descripcion = "Curso de Java",
                   Titulo = "Master en Java Spring desde las raices",
                   FechaCreacion = DateTime.Now,
                   FechaPublicacion = DateTime.Now.AddYears(2),
                   Precio = 25
               }
           );

            modelBuilder.Entity<Curso>().HasData(
               new Curso
               {
                   CursoId = Guid.NewGuid(),
                   Descripcion = "Curso de Unit Test para NET Core",
                   Titulo = "Master en UNIT Test con CQRS ",
                   FechaCreacion = DateTime.Now,
                   FechaPublicacion = DateTime.Now.AddYears(2),
                   Precio = 100
               }
           );


            //base.OnModelCreating(modelBuilder);
        }
    }
}