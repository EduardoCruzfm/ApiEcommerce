using ApiEcommerce.Repository;
using ApiEcommerce.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.   
var dbconnectionString = builder.Configuration.GetConnectionString("ConexionSql");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(dbconnectionString));
builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(cfg =>
{
    // Escanea todos los perfiles en el ensamblado de Program, version 15.0 
    cfg.AddMaps(typeof(Program).Assembly);
});

// Registrar perfiles explícitos:
// builder.Services.AddAutoMapper(cfg =>
//   cfg.AddProfile<CategoryProfile>()
// );

// Agrega el explorador de endpoints y OpenAPI nativo
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
