using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblProfile")]
public class Profile : OffshoreDataModel
{
    [Column("ProfileTypeID")] public uint ProfileType { get; set; }
    [Column("ProfileName")] public string? Name { get; set; }
    [Column("ProfileUserName")] public string? Username { get; set; }
    [Column("ProfilePassword")] public string? Password { get; set; }
    [Column("ProfileLangID")] public uint LanguageId { get; set; }
    [Column("ProDateFormat")] public uint DateFormat { get; set; }
    [Column("ProMobile")] public string? Telephone { get; set; }
    [Column("ProEmail")] public string? Email { get; set; }
    [Column("ProAlarmSMSActive")] public bool SmsAlarm { get; set; } = false;
    [Column("ProAlarmEmailActive")] public bool EmailAlarm { get; set; } = false;
    [Column("ProAlarmSoundOn")] public bool SoundAlarm { get; set; } = false;
    [Column("ProDefaultSite")] public string? DefaultSite { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Profile>(modelBuilder);
    }
}