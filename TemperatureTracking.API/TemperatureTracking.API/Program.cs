
using TemperatureTracking.API.Hubs;
using TemperatureTracking.API.Workers;
using TemperatureTracking.Business.Extensions;
using TemperatureTracking.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddHostedService<TemperatureWorker>();

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", b => b
        .WithOrigins("http://localhost:4200") 
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers(); 
app.MapHub<TemperatureHub>("/temperatureHub");

app.Run();