using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("TelephoneTypes", Schema ="biz")]
public class TelephoneType : NamedOffshoreDataModel
{
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<TelephoneType>(modelBuilder);
    }
}