using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings.contexts;

public interface IUserDataContext : IOffshoreDbContext
{
    DbSet<Permission> Permissions { get; }
    DbSet<Role> Roles { get; }
    DbSet<User> Users { get; }
    DbSet<TelephoneNumber> TelephoneNumbers { get; }
}
