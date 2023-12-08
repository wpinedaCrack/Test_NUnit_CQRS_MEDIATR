using AutoFixture;
using AutoMapper;
using Education.Aplication.NUnitTest.Helper;
using Education.Application.Cursos;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Education.Aplication.NUnitTest.Cursos
{
    [TestFixture]
    public class GetCursoByIdQueryNUnitTest
    {
        private GetCursoByIdQuery.GetCursoByIdQueryHandler handlerByIdCurso;
        private Guid cursoIdTest;

        [SetUp]
        public void Setup()
        {
            //////  PASO 1  Emular al context que representa el EF
            cursoIdTest = new Guid("2ce24c4d-df93-4620-ba47-c8065633775f");
            var fixture = new Fixture();                             //Genera data de pruebas
            var cursoRecords = fixture.CreateMany<Curso>().ToList(); //Crear lista

            cursoRecords.Add(fixture.Build<Curso>()
                             .With(x => x.CursoId, cursoIdTest)
                             .Create());                             // crear registro con un cursoId vacio

            // Crear instancia de Entity Framework en memory de tipo aleatoria Punto y asi es papa
            var options = new DbContextOptionsBuilder<EducacionDbContext>()
                              .UseInMemoryDatabase(databaseName: $"EducacionDbContext-{Guid.NewGuid()}")
                              .Options;

            var educacionDbContextFake = new EducacionDbContext(options);    // Obtengo el dbContext
            educacionDbContextFake.Cursos.AddRange(cursoRecords);
            educacionDbContextFake.SaveChanges();

            /// PASO 2  Emular el Mapping profile.
            var mapConfig = new MapperConfiguration(x => { x.AddProfile(new MappingTest()); });

            var mapper = mapConfig.CreateMapper();

            // PASO 3  Instanciar la clase GetCursoQuery, GetCursoQueryHandler y pasarle como parametros 
            // los objetos context y mapping GetCursoQueryHandler(context, _mapper)
            handlerByIdCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(educacionDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsNotNull()
        {
            GetCursoByIdQuery.GetCursoByIdQueryRequest request = new()
            {
                Id = cursoIdTest
            };
            
            var resultado = await handlerByIdCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultado);

        }

    }
}