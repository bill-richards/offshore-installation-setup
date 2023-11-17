using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblConfig")]
public class SiteConfiguration : OffshoreDataModel
{
    [Column("CommPort")] public uint PortNumber { get; set; }
    [Column("CommBaud")] public uint BaudRate { get; set; }
    public uint TcpPort { get; set; }
    [Column("LogDataMonths")] public uint LogData { get; set; }
    public string? SiteName { get; set; }
    [Column("SyncSQL")] public string SqlConnection { get; set; } = VALUE_NOT_SET;
    [Column("SyncLicence")] public string SynchronisationLicence { get; set; } = VALUE_NOT_SET;
    [Column("SyncPassword")] public string SynchronisationPassword { get; set; } = VALUE_NOT_SET;
    public uint TimeZone { get; set; }
    public bool AudibleAlarm { get; set; } = false;
    public bool SmsAlarm { get; set; } = false;
    [Column("SmsFrom")] public string SmsSender { get; set; } = "TELEMETRY";
    [Column("SmsMInterval")] public uint SmsInterval { get; set; }
    public bool EmailAlarm { get; set; } = false;
    public bool Modbus { get; set; } = false;
    public bool Pilot { get; set; } = false;

    public uint ReceiverType { get; set; }
    [Column("SyncUsername")] public string? SynchronisationUser { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SiteConfiguration>(modelBuilder);
    }
}
