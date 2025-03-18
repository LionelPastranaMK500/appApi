using appApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Instanciar la clase Configuracion para obtener la cadena de conexion de appsettings.json
var Configuracion = new Configuracion(builder.Configuration.GetConnectionString("bdProcesadores"));
builder.Services.AddSingleton(Configuracion);

//agregar al contenedor la dependencia de la interface y la clase CRUDProcesador
builder.Services.AddScoped<IProcesador, CRUDProcesador>();
//agregar al contenedor la dependencia de la interface y la clase CRUDbenchmark
builder.Services.AddScoped<IBenchmark, CRUDbenchmark>();

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
