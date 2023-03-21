using DiaDeFeira.API.Infraestructure.Configurations;
using DiaDeFeira.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomSwagger();
builder.Services.AddRepositories();

var app = builder.Build();

app.UseCustomSwagger();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

//TODO : Adicionar autenticação
//TODO : Adicionar métodos de edição de Usuários
//TODO : Realizar testes de unidade
//TODO : Realizar testes de integração
