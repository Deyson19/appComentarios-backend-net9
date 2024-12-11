using AppComentarios.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//*Connection String
string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//*Provide Sql Server
builder.Services.AddDbContext<ComentariosDbContext>(op =>
{
     op.UseSqlServer(connectionString);
});

//*Habilitar los CORS
string[] frontEndsAppUrls = [
     "http://localhost:4200/",
"http://localhost:3000/",
"http://localhost:5173/",
];

builder.Services.AddCors(
     op =>
     {
          op.AddPolicy("frontEnd", builder =>
          {
               builder.WithOrigins(frontEndsAppUrls)
               .SetIsOriginAllowedToAllowWildcardSubdomains()
               .AllowAnyMethod()
               .AllowAnyHeader();
          });
     }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     // app.MapOpenApi();
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseCors("frontEnd");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
