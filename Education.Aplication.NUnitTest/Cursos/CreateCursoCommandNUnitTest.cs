using AutoFixture;
using AutoMapper;
using Education.Application.Cursos;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Aplication.NUnitTest.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTest
    {
        private CreateCursoCommand.CreateCursoCommandHandler handlerCreateCursos;

        [SetUp]
        public void Setup()
        {
            ///  PASO 1  Emular al context que representa el EF
            var fixture = new Fixture();                             //Genera data de pruebas
            var cursoRecords = fixture.CreateMany<Curso>().ToList(); //Crear lista

            cursoRecords.Add(fixture.Build<Curso>()
                             .With(x => x.CursoId, Guid.Empty)
                             .Create());                             // crear registro con un cursoId vacio

            // Crear instancia de Entity Framework en memory de tipo aleatoria Punto y asi es papa
            var options = new DbContextOptionsBuilder<EducacionDbContext>()
                              .UseInMemoryDatabase(databaseName: $"EducacionDbContext-{Guid.NewGuid()}")
                              .Options;

            var educacionDbContextFake = new EducacionDbContext(options);    // Obtengo el dbContext
            educacionDbContextFake.Cursos.AddRange(cursoRecords);
            educacionDbContextFake.SaveChanges();

            /// PASO 3
            handlerCreateCursos = new CreateCursoCommand.CreateCursoCommandHandler(educacionDbContextFake);
        }

        [Test]
        public async Task CreateCursoCommand_InputCurso_ReturnsNumber()
        {
            CreateCursoCommand.CreateCursoCommandRequest request = new();
            request.FechaPublicacion = DateTime.UtcNow.AddDays(59);
            request.Titulo = "Libro de Pruebas Automaticas en .NET";
            request.Descripcion = "Aprende a crear unit test desde cero";
            request.Precio = 99;

            var resultados = await handlerCreateCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.That(resultados, Is.EqualTo(Unit.Value));
        }
    }
}
