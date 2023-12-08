using AutoFixture;
using AutoMapper;
using Education.Aplication.NUnitTest.Helper;
using Education.Application.Cursos;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Education.Aplication.NUnitTest.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTest
    {
        private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;
        
        [SetUp]
        public void Setup()
        {
            //////  PASO 1
            var fixture = new Fixture();                             //Genera data de pruebas
            var cursoRecords = fixture.CreateMany<Curso>().ToList(); //Crear lista

            cursoRecords.Add(fixture.Build<Curso>()
                             .With(x=>x.CursoId, Guid.Empty)
                             .Create());                             // crear registro con un cursoId vacio

            // Crear instancia de Entity Framework en memory de tipo aleatoria Punto y asi es papa
            var options = new DbContextOptionsBuilder<EducacionDbContext>()
                              .UseInMemoryDatabase(databaseName: $"EducacionDbContext-{Guid.NewGuid()}")
                              .Options;

            var educacionDbContextFake = new EducacionDbContext(options);    // Obtengo el dbContext
            educacionDbContextFake.Cursos.AddRange(cursoRecords);
            educacionDbContextFake.SaveChanges();

            /// PASO 2
            var mapConfig = new MapperConfiguration(x => { x.AddProfile(new MappingTest()); });

            var mapper = mapConfig.CreateMapper();

            /// PASO 3
            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educacionDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {
            /* 1. Emular al context que representa el EF
               2. Emular el Mapping profile.
               3. Instanciar la clase GetCursoQuery, GetCursoQueryHandler y pasarle como parametros 
                  los objetos context y mapping GetCursoQueryHandler(context, _mapper) */

            GetCursoQuery.GetCursoQueryRequest request = new GetCursoQuery.GetCursoQueryRequest();
            var resultados = await handlerAllCursos.Handle(request,
                                                           new System.Threading.CancellationToken());//GetCursoQueryRequest request, CancellationToken cancellationToken


            Assert.IsNotNull(resultados);

        }

    }
}