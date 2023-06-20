using Microsoft.EntityFrameworkCore;
using ProEventosApplication.Contratos;
using ProEventosApplication.Service;
using ProEventosPersistence.Contextos;
using ProEventosPersistence.Contratos;
using ProEventosPersistence.Persist;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProEventosContext>
	(opts =>
	{
		opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
	});

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ILoteService, LoteService>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IEventoPersist, EventosPersist>();
builder.Services.AddScoped<ILotePersist, LotePersist>();
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
