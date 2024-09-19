using Notely.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Notely.Services;
using Notely.Models.Profiles;
using Notely.Repository;
using System.Globalization;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Later check if you can add assemblies from another project.
builder.Services.AddAutoMapper(typeof(NotesProfile));
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddDbContext<NotesDbContext>(dbContextOptions => dbContextOptions.UseSqlite("Data Source=CityInfo.db"));
//builder.Services.AddDbContext<NotesDbContext>(dbContextOptions => dbContextOptions.UseSqlServer("Server=tcp:bhanuteja.database.windows.net,1433;Initial Catalog=notely;Persist Security Info=False;User ID=bhannuteja917;Password=Iamindian%402002;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddDbContext<NotesDbContext>();

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
