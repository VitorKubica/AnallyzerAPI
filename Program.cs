using AnallyzerAPI.Database;
using AnallyzerAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AnallyzerDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleAnallyzer"));
});

builder.Services.AddScoped<ICampaignService, CampaignService>();

builder.Services.AddControllers();

// Configurando o Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnallyzerAPI", Version = "v1" });

    // Incluindo o XML de documentação para descrever os modelos
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
