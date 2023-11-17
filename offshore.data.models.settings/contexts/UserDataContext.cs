using Microsoft.EntityFrameworkCore;
using offshore.services;

namespace offshore.data.models.settings.contexts;

public class UserDataContext : OffshoreDbContext, IUserDataContext
{
    private readonly IDataConfigurationFile _configFile;

    public UserDataContext(IUsersSchema databaseConfiguration, IDataConfigurationFile configFile, string databaseType = "SqlExpress")
        : base(databaseConfiguration, databaseType)
    {
        _configFile = configFile;
    }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    
    /* From the biz schema */
    public DbSet<TelephoneNumber> TelephoneNumbers { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_configFile.SchemataConfiguration.UsersSchema);

        new Permission().OnModelCreating(modelBuilder);
        new Role().OnModelCreating(modelBuilder);
        new User().OnModelCreating(modelBuilder);

        new TelephoneNumber().OnModelCreating(modelBuilder);
    }
}
