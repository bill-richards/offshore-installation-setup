using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

var connectionString = "mongodb://localhost:27017";
var databaseName = "simple-configuration-test";
var client = new MongoClient(connectionString);
var database = client.GetDatabase(databaseName);

var db = new Context(new DbContextOptionsBuilder()
                                        .UseMongoDB(client, databaseName).Options);


var user = new User() { GivenName = "test", FamilyName = "user" };
var existing = db.Users.FirstOrDefault(u => u.FamilyName == user.FamilyName && u.GivenName == user.GivenName);
if (existing == null) db.Users.Add(user);
else user = existing;

Console.WriteLine($"User = {user.GivenName} {user.FamilyName} Created at {user.CreationDate}");

var configuration = new Configuration { Owner = user };
var existingConfig = db.Configurations.FirstOrDefault(c => c.OwnerId.Equals(user.Id));
if (existingConfig == null) db.Configurations.Add(configuration);
else configuration = existingConfig;

if(db.ChangeTracker.HasChanges()) db.SaveChanges();

Console.WriteLine($"Configuration owner = {configuration!.Owner?.GivenName} {configuration.Owner?.FamilyName}");
Console.ReadLine();

var english = new SupportedLanguage() { ShortName = "en", Name = "English" };
var existingLanguage = db.Languages.FirstOrDefault(l => l.ShortName!.Equals(english.ShortName));
if (existingLanguage == null) db.Languages.Add(english);
else english = existingLanguage;

var spanish = new SupportedLanguage() { ShortName = "es", Name = "Español" };
existingLanguage = db.Languages.FirstOrDefault(l => l.ShortName!.Equals(spanish.ShortName));
if (existingLanguage == null) db.Languages.Add(spanish);
else spanish = existingLanguage;

var translatableString = new Translatable() { Value = "NAME_STRING" };
var existingString = db.Translatables.FirstOrDefault(s => s.Value!.Equals(translatableString.Value));
if (existingString == null) db.Translatables.Add(translatableString);
else translatableString = existingString;

var translations = db.Translations;
var en_translation = new Translation() { Language = english, Translatable = translatableString, Value = "Name" };
var existingTranslation = translations?.FirstOrDefault(t => t.LanguageId.Equals(english.Id) && t.TranslatableId.Equals(translatableString.Id));
if (existingTranslation == null) db.Translations.Add(en_translation);
else en_translation = existingTranslation;

var es_translation = new Translation() { Language = spanish, Translatable = translatableString, Value = "Nombre" };
existingTranslation = translations?.FirstOrDefault(t => t.LanguageId.Equals(spanish.Id) && t.TranslatableId.Equals(translatableString.Id));
if (existingTranslation == null) db.Translations.Add(es_translation);
else en_translation = existingTranslation;

if (db.ChangeTracker.HasChanges()) db.SaveChanges();

foreach (var t in translations!)
{
    Console.WriteLine($"{t.Translatable!.Value} {t.Language!.ShortName} {t.Value}");
}


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

public class SupportedLanguage
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public string? ShortName { get; set; }
    public string? Name { get; set; }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupportedLanguage>(e =>
        {
            e.Property<ObjectId>(nameof(Id)).ValueGeneratedNever();
            e.HasIndex(nameof(Id));
            e.Property(p => p.Name).IsRequired();
            e.Property(p => p.ShortName).IsRequired();
        });
    }
}

public class Translatable
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public string? Value { get; set; }

    public virtual ICollection<Translation>? Translations { get; set; }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translatable>(e =>
        {
            e.Property<ObjectId>(nameof(Id)).ValueGeneratedNever();
            e.HasIndex(nameof(Id));
            e.Property(p => p.Value).IsRequired();
            e.HasMany(p => p.Translations).WithOne(t => t.Translatable)
                                          .HasForeignKey("TranslatableId")
                                          .HasPrincipalKey(nameof(Id));
        });
    }
}

public class Translation
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public ObjectId LanguageId { get; set; }
    public ObjectId TranslatableId { get; set; }

    public virtual SupportedLanguage? Language { get; set; }
    public virtual Translatable? Translatable { get; set; }

    public string? Value { get; set; }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>(e =>
        {
            e.Property<ObjectId>(nameof(Id)).ValueGeneratedNever();
            e.HasIndex(nameof(Id));
            e.Property(p => p.Value).IsRequired();
            e.HasOne(p => p.Language);
            e.HasOne(p => p.Translatable).WithMany(e => e.Translations)
                                         .HasForeignKey("TranslatableId")
                                         .HasPrincipalKey(nameof(Id));
        });
    }
}


public class User
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public ICollection<Configuration>? Configurations { get; init; }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.Property<ObjectId>(nameof(Id)).ValueGeneratedNever();
            e.HasKey(e => e.Id);
            e.HasIndex(new string[] { nameof(FamilyName), nameof(GivenName) });
            e.HasMany(e => e.Configurations).WithOne(e => e.Owner)
                                            .HasForeignKey(c => c.OwnerId)
                                            .HasPrincipalKey(nameof(Id)).IsRequired();
        });
    }
}

public class Configuration
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public ObjectId? OwnerId { get; set; }

    public User? Owner { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuration>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasOne(c=>c.Owner).WithMany(u=>u.Configurations)
                                .HasForeignKey(c=>c.OwnerId)
                                .HasPrincipalKey(nameof(Id)).IsRequired();
        });
    }
}