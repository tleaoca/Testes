using BackEnd_1.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerSetup();

InjecaoDependencia.RegistrarServicos(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
