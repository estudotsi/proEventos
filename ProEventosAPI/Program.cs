using Microsoft.EntityFrameworkCore;
using ProEventosPersistence.Contextos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProEventosContext>
	(opts =>
	{
		opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
	});

builder.Services.AddControllers();
builder.Services.AddCors();
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

app.UseCors
	(
	 cors => cors.AllowAnyHeader()
				 .AllowAnyMethod()
				 .AllowAnyOrigin()
	);

app.MapControllers();

app.Run();
