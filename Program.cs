using AnallyzerAPI.Database;
using AnallyzerAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurando o DbContext para usar o Oracle SQL
builder.Services.AddDbContext<AnallyzerDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleAnallyzer"));
});

// Registrando o CampaignService na inje��o de depend�ncia
builder.Services.AddScoped<ICampaignService, CampaignService>();

// Adicionando suporte para controllers (API)
builder.Services.AddControllers();

// Configurando o Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurando o pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeando os controllers da API
app.MapControllers();

app.Run();
