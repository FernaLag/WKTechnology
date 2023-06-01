using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WKTechnology.Core.Services;
using WKTechnology.Persistence;
var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<CategoriaService>();

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();