using ServeSchools.WebApi;
using ServeSchools.WebApi.Mappings;
using static ServeSchools.Infrastructure.DependencyInjection;
using static ServeSchools.WebApi.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var mapper = MappingConfig.Initialize();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add custom services
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
