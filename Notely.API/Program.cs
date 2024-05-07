using Notely.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Notely.Services;
using Notely.Models.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Later check if you add assemblies from another project.
builder.Services.AddAutoMapper(typeof(NotesProfile));
builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddDbContext<NotesDbContext>(dbContextOptions => dbContextOptions.UseSqlite("Data Source=CityInfo.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
