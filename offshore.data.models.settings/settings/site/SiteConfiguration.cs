using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

public class SiteConfiguration : OffshoreDataModel
{
    [Required]
    public uint PortNumber { get; set; }
    [Required]
    public uint BaudRate { get; set; }
    [Required]
    public uint TcpPort { get; set; }
    [Required]
    public uint LogData { get; set; }
    [Required]
    public string? SqlConnection { get; set; }
    [Required, Column("SyncLicence")]
    public string? SynchronisationLicence { get; set; }
    [Required, Column("SyncPassword")]
    public string? SynchronisationPassword { get; set; }
    [Required]
    public uint TimeZone { get; set; }
    [Required]
    public bool AudibleAlarm { get; set; } = false;
    public bool SmsAlarm { get; set; } = false;
    [Required]
    public string? SmsSender { get; set; } = "TELEMETRY";
    [Required]
    public uint SmsInterval { get; set; }
    public bool EmailAlarm { get; set; } = false;
    [Required]
    public bool Modbus { get; set; } = false;
    [Required]
    public bool Pilot { get; set; } = false;

    [Required]
    public virtual Receiver? ReceiverType { get; set; }
    public User? EmailUser { get; set; }
    public User? SmsUser { get; set; }
    public User? SyncUser { get; set; }
    [Required] public bool IsActive { get; set; } = false;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SiteConfiguration>(modelBuilder);
        modelBuilder.Entity<SiteConfiguration>(e =>
        {
            e.HasOne(p => p.ReceiverType);
            e.HasOne(p => p.EmailUser);
            e.HasOne(p => p.SmsUser);
            e.HasOne(p => p.SyncUser);
        });
    }
}
