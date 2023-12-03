using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings;

public class Receiver : NamedOffshoreDataModel
{
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Receiver>(modelBuilder);
    }
}
