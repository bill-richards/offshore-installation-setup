using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblConfig")]
public class SiteConfiguration : OffshoreDataModel
{
    //    [Column("ConfigId")]
    public uint Id { get; set; }

    public uint ReceiverType { get; set; }

    //[Column("CommPort")]
    public uint PortNumber { get; set; }

    //[Column("CommBaud")]
    public uint BaudRate { get; set; }

    //[Column("TCPPort")]
    public uint TcpPort { get; set; }

    //[Column("LogDataMonths")]
    public uint LogData { get; set; }

    public Site? Site { get; set; }

    //[Column("SyncSQL")]
    public string SqlConnection { get; set; } = VALUE_NOT_SET;

    //[Column("SyncLicense")]
    public string SynchronisationLicence { get; set; } = VALUE_NOT_SET;

    //[Column("SyncUsername")]
    public string SynchronisationUser { get; set; } = "sa";

    //    [Column("SyncPassword")]
    public string SynchronisationPassword { get; set; } = VALUE_NOT_SET;

    public uint TimeZone { get; set; }

    public bool AudibleAlarm { get; set; } = false;

    //[Column("SMSAlarm")]
    public bool SmsAlarm { get; set; } = false;

    //[Column("SMSFrom")]
    public string SmsSender { get; set; } = "TELEMETRY";

    //[Column("SMSInterval")]
    public uint SmsInterval { get; set; }

    public bool EmailAlarm { get; set; } = false;

    public bool Modbus { get; set; } = false;

    public bool Pilot { get; set; } = false;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SiteConfiguration>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}
