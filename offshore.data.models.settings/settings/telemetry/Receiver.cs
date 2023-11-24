using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Receiver : OffshoreDataModel
{
    [Required]
    public string Type { get; set; } = "";
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Receiver>(modelBuilder);
    }
}
