using Microsoft.EntityFrameworkCore;
using Repository.EF.UoW.Core;
using Repository.EF.UoW.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add values from a json file
var builderConfig = new ConfigurationBuilder();

// add values from a json file
builderConfig.AddJsonFile("appsettings.json");
IConfigurationRoot config = builderConfig.Build();

builder.Services.AddDbContext<DBContext>(options =>
        options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
//Scoped Unit of work for atomicity transactions
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
