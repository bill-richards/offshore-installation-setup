using Microsoft.EntityFrameworkCore;


var connectionString = $"server=.\\EXPRESS_2019;database=simple-configuration-test;trusted_connection=true;TrustServerCertificate=True";
var db = new Context(new DbContextOptionsBuilder()
                                        .UseSqlServer(connectionString).Options);
db.Database.EnsureCreated();

var user = new User() { GivenName = "test", FamilyName = "user" };

var existing = db.Users.FirstOrDefault(u => u.FamilyName == user.FamilyName && u.GivenName == user.GivenName);
if (existing == null) db.Users.Add(user);
else user = existing;

Console.WriteLine($"User = {user.GivenName} {user.FamilyName} Created at {user.CreationDate}");

var configuration = new Configuration { Owner = user };
var existingConfig = db.Configurations.Include(c => c.Owner).FirstOrDefault(c => EF.Property<uint>(c.Owner!, "Id") == db.Entry(user).Property<uint>("Id").CurrentValue);
if (existingConfig == null) db.Configurations.Add(configuration);
else configuration = existingConfig;

if (db.ChangeTracker.HasChanges()) db.SaveChanges();

Console.WriteLine($"Configuration owner = {configuration!.Owner?.GivenName} {configuration.Owner?.FamilyName} Created at {configuration.CreationDate}");
Console.ReadLine();

var english = new SupportedLanguage() { ShortName = "en", Name="English" };
var existingLanguage = db.Languages.FirstOrDefault(l => l.ShortName!.Equals(english.ShortName));
if(existingLanguage == null) db.Languages.Add(english);
else english = existingLanguage;

var spanish = new SupportedLanguage() { ShortName = "es", Name = "Español" };
existingLanguage = db.Languages.FirstOrDefault(l => l.ShortName!.Equals(spanish.ShortName));
if (existingLanguage == null) db.Languages.Add(spanish);
else spanish = existingLanguage;

var translatableString = new Translatable() { Value="NAME_STRING" };
var existingString = db.Translatables.FirstOrDefault(s => s.Value!.Equals(translatableString.Value));
if(existingString == null) db.Translatables.Add(translatableString);
else translatableString = existingString;

var translations = db.Translations.Include(s => s.Translatable);                                         

var en_translation = new Translation() { Language = english, Translatable = translatableString, Value = "Name" };
var existingTranslation = translations.FirstOrDefault(t => EF.Property<uint>(t.Language!, "Id").Equals(db.Entry(english).Property<uint>("Id").CurrentValue!) 
                                && EF.Property<uint>(t.Translatable!, "Id").Equals(db.Entry(translatableString).Property<uint>("Id").CurrentValue!));
if(existingTranslation == null) db.Translations.Add(en_translation);
else en_translation = existingTranslation;

var es_translation = new Translation() { Language = spanish, Translatable = translatableString, Value = "Nombre" };
existingTranslation = translations.FirstOrDefault(t => EF.Property<uint>(t.Language!, "Id").Equals(db.Entry(spanish).Property<uint>("Id").CurrentValue!)
                                && EF.Property<uint>(t.Translatable!, "Id").Equals(db.Entry(translatableString).Property<uint>("Id").CurrentValue!));
if (existingTranslation == null) db.Translations.Add(es_translation);
else es_translation = existingTranslation;

if (db.ChangeTracker.HasChanges()) db.SaveChanges();

foreach (var t in translations)
{
    Console.WriteLine($"{t.Translatable!.Value} {t.Language!.ShortName} {t.Value}");
}
Console.ReadLine();

public class Context : DbContext
{
    public Context(DbContextOptions options)
        : base(options) { }

    public DbSet<User> Users { get; init; }
    public DbSet<Configuration> Configurations { get; init; }
    public DbSet<SupportedLanguage> Languages { get; init; }
    public DbSet<Translatable> Translatables { get; init; }
    public DbSet<Translation> Translations { get; init; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new User().OnModelCreating(modelBuilder);
        new Configuration().OnModelCreating(modelBuilder);
        new SupportedLanguage().OnModelCreating(modelBuilder);
        new Translatable().OnModelCreating(modelBuilder);
        new Translation().OnModelCreating(modelBuilder);
    }
}

public class SupportedLanguage : OffshoreDataModel
{
    public string? ShortName { get; set; }
    public string? Name { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupportedLanguage>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex("Id");
            e.Property(p => p.Name).IsRequired();
            e.Property(p => p.ShortName).IsRequired();
        });
    }
}

public class Translatable : OffshoreDataModel
{
    public string? Value { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translatable>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex("Id");
            e.Property(p => p.Value).IsRequired();
        });
    }
}

public class Translation : OffshoreDataModel
{
    public virtual SupportedLanguage? Language { get; set; }
    public virtual Translatable? Translatable { get; set; }

    public string? Value { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex("Id");
            e.Property(p => p.Value).IsRequired();
            e.HasOne(p => p.Language);
            e.HasOne(p => p.Translatable); 
        });
    }
}


public class User : OffshoreDataModel
{
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public ICollection<Configuration>? Configurations { get; init; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex(new string[] { "FamilyName", "GivenName" });
            e.HasMany(e => e.Configurations).WithOne(e => e.Owner)
                                            .HasForeignKey("OwnerId")
                                            .HasPrincipalKey("Id").IsRequired(); ;
        });
    }
}

public class Configuration : OffshoreDataModel
{
    public User? Owner { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuration>(e =>
        {
            e.Property<uint>("Id");
            e.HasOne(c => c.Owner).WithMany(u=>u.Configurations)
                                   .HasForeignKey("OwnerId")
                                   .HasPrincipalKey("Id").IsRequired();
        });
    }
}

public abstract class OffshoreDataModel
{
    public const string VALUE_NOT_SET = "not set";
    public abstract void OnModelCreating(ModelBuilder modelBuilder);
}
