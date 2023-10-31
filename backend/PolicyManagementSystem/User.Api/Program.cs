using Serilog;
using User.Service.Role;
using User.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.LogstashHttp("http://localhost:5000")
    .Enrich.FromLogContext());
//builder.Services.AddScoped<IPolicyService, PolicyService>();
builder.Services.AddScoped<ICostumerService, CostumerService>();
// Add services to the container.

builder.Services.AddControllers();
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
