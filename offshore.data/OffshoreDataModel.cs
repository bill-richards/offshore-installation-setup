using Microsoft.EntityFrameworkCore;

namespace offshore.data;

public abstract class OffshoreDataModel
{
    public const string VALUE_NOT_SET = "not set";
    public abstract void OnModelCreating(ModelBuilder modelBuilder);
}
