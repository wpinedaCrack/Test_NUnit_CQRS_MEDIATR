using Education.Application.Cursos;
using Education.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EducacionDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Registra todos los controladores de MediatR 
builder.Services.AddMediatR(typeof(GetCursoQuery.GetCursoQueryHandler).Assembly);

// Agrega el servicio de controladores al contenedor de servicios.
builder.Services.AddControllers() // Configura FluentValidation para que valide las solicitudes de los controladores.
    .AddFluentValidation(x =>// Registra validadores desde la misma assembly que contiene CreateCursoCommandRequest.
       x.RegisterValidatorsFromAssemblyContaining<CreateCursoCommand>());

builder.Services.AddAutoMapper(typeof(GetCursoQuery.GetCursoQueryHandler));

builder.Services.AddCors(o=>o.AddPolicy("corsApp",builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("corsApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();