using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task = Core.Task;


namespace DataAcces;

public class DataBaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Evaluation360> Evaluation360s { get; set; }
    public DbSet<BehaviorEvaluation> BehaviorEvaluations { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskEvaluation> TaskEvaluations { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfigureBehaviorEvaluation());
        modelBuilder.ApplyConfiguration(new ConfigureEvaluation360());
        modelBuilder.ApplyConfiguration(new ConfigureGroup());
        modelBuilder.ApplyConfiguration(new ConfigureTask());
        modelBuilder.ApplyConfiguration(new ConfigureTaskEvaluations());
        modelBuilder.ApplyConfiguration(new ConfigureUser());
    }
}