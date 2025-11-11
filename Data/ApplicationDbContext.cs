using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    

    // Representación una tabla de categorías en la base de datos
    // por convención, el nombre de la tabla será "Categories", en plural
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}