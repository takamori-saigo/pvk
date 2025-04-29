using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DataAcces;

public class DataBaseContext : DbContext
{
    private readonly IConfiguration _configuration;


    public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
}